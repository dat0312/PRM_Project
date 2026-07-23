using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Models;

namespace MyBackendAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<ScheduleRequest> ScheduleRequests { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TeacherSubject> TeacherSubjects { get; set; }

        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<ClubMember> ClubMembers { get; set; }
        public DbSet<AppRequest> AppRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.ConfigureWarnings(warnings => 
                warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure many-to-many relationship UserRole
            modelBuilder.Entity<UserRole>()
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            // Configure many-to-many relationship TeacherSubject
            modelBuilder.Entity<TeacherSubject>()
                .HasKey(ts => new { ts.TeacherId, ts.SubjectId });

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Teacher)
                .WithMany(t => t.TeacherSubjects)
                .HasForeignKey(ts => ts.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TeacherSubject>()
                .HasOne(ts => ts.Subject)
                .WithMany(s => s.TeacherSubjects)
                .HasForeignKey(ts => ts.SubjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Teacher)
                .WithMany(u => u.Schedules)
                .HasForeignKey(s => s.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Class)
                .WithMany(c => c.Schedules)
                .HasForeignKey(s => s.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Room)
                .WithMany()
                .HasForeignKey(s => s.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Class)
                .WithMany(c => c.Students)
                .HasForeignKey(u => u.ClassId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Child)
                .WithMany()
                .HasForeignKey(u => u.ChildId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ScheduleRequest>()
                .HasOne(sr => sr.Schedule)
                .WithMany()
                .HasForeignKey(sr => sr.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ScheduleRequest>()
                .HasOne(sr => sr.Teacher)
                .WithMany()
                .HasForeignKey(sr => sr.TeacherId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Notification>()
                .HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Student)
                .WithMany()
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Subject)
                .WithMany()
                .HasForeignKey(g => g.SubjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Grade>()
                .HasOne(g => g.Class)
                .WithMany()
                .HasForeignKey(g => g.ClassId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configure Club relationships
            modelBuilder.Entity<Club>()
                .HasOne(c => c.President)
                .WithMany(u => u.ClubsLed)
                .HasForeignKey(c => c.PresidentId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<ClubMember>()
                .HasKey(cm => new { cm.ClubId, cm.UserId });

            modelBuilder.Entity<ClubMember>()
                .HasOne(cm => cm.Club)
                .WithMany(c => c.Members)
                .HasForeignKey(cm => cm.ClubId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ClubMember>()
                .HasOne(cm => cm.User)
                .WithMany(u => u.ClubMemberships)
                .HasForeignKey(cm => cm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Make PhoneNumber unique
            modelBuilder.Entity<User>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();

            // Make Email unique
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            // Make StudentId unique if not null
            modelBuilder.Entity<User>()
                .HasIndex(u => u.StudentId)
                .IsUnique()
                .HasFilter("[StudentId] IS NOT NULL");
                
            modelBuilder.Entity<Notification>()
                .HasIndex(n => n.UserId);

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, RoleName = "Admin" },
                new Role { Id = 2, RoleName = "Student" },
                new Role { Id = 3, RoleName = "Teacher" },
                new Role { Id = 4, RoleName = "Parent" }
            );

            // Seed Classes (9 Current Classes + 3 History Classes)
            var classes = new List<Class>();
            int classId = 1;
            int[] grades = { 10, 11, 12 };
            string[] suffixes = { "A", "A01", "D" };
            
            foreach (var grade in grades)
            {
                foreach (var suffix in suffixes)
                {
                    int? homeroomTeacherId = null;
                    if (classId == 1) homeroomTeacherId = 100; // 10A - GV Bắt buộc làm GVCN
                    if (classId == 2) homeroomTeacherId = 101; // 10A01
                    if (classId == 7) homeroomTeacherId = 105; // 12A
                    
                    string cohort = grade == 12 ? "K1" : (grade == 11 ? "K2" : "K3");
                    classes.Add(new Class { Id = classId++, Name = $"{grade}{suffix}", Grade = grade, Cohort = cohort, HomeroomTeacherId = homeroomTeacherId });
                }
            }
            
            // Lịch sử cho K1 (Hiện đang học lớp 12)
            classes.Add(new Class { Id = 10, Name = "10A", Grade = 10, Cohort = "K1" });
            classes.Add(new Class { Id = 11, Name = "11A", Grade = 11, Cohort = "K1" });
            // Lịch sử cho K2 (Hiện đang học lớp 11)
            classes.Add(new Class { Id = 12, Name = "10A", Grade = 10, Cohort = "K2" });

            modelBuilder.Entity<Class>().HasData(classes);

            // Seed Rooms
            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Name = "A101" },
                new Room { Id = 2, Name = "A102" },
                new Room { Id = 3, Name = "B204" }
            );

            // Seed Users
            var users = new List<User>();
            
            // Admin
            users.Add(new User 
            { 
                Id = 1, 
                PhoneNumber = "0352578129", 
                Email = "datvideo04@gmail.com",
                Password = "denhat123", 
                FullName = "Phan Thanh Dat",
                StudentId = "ADMIN001",
                ClassId = null
            });



            // Seed 27 Students (3 per class)
            int userId = 3;
            foreach (var c in classes)
            {
                for (int i = 1; i <= 3; i++)
                {
                    users.Add(new User
                    {
                        Id = userId,
                        PhoneNumber = $"090000{userId:D4}",
                        Email = $"student{userId}@fpt.edu.vn",
                        Password = "password123",
                        FullName = $"Student {userId} - {c.Name}",
                        StudentId = $"STU{userId:D5}",
                        ClassId = c.Id
                    });
                    userId++;
                }
            }

            // Seed Parents for each Student
            for (int i = 3; i < userId; i++)
            {
                users.Add(new User
                {
                    Id = i + 200,
                    PhoneNumber = $"080000{i:D4}",
                    Email = $"parent{i}@fpt.edu.vn",
                    Password = "password123",
                    FullName = $"Phụ huynh của Student {i}",
                    StudentId = null,
                    ClassId = null,
                    ChildId = i
                });
            }

            // ------------------------------------
            // Seed new Teachers for each Group
            // ------------------------------------
            users.Add(new User 
            { 
                Id = 100, 
                PhoneNumber = "0333333100", 
                Email = "gv_bb@fpt.edu.vn",
                Password = "password123", 
                FullName = "Giáo viên Bắt buộc",
                StudentId = "GVBB01",
                ClassId = null
            });
            users.Add(new User 
            { 
                Id = 101, 
                PhoneNumber = "0333333101", 
                Email = "gv_tn@fpt.edu.vn",
                Password = "password123", 
                FullName = "Giáo viên Tự nhiên",
                StudentId = "GVTN01",
                ClassId = null
            });
            users.Add(new User 
            { 
                Id = 102, 
                PhoneNumber = "0333333102", 
                Email = "gv_xh@fpt.edu.vn",
                Password = "password123", 
                FullName = "Giáo viên Xã hội",
                StudentId = "GVXH01",
                ClassId = null
            });
            
            // ------------------------------------
            // Seed new Teachers for each Grade
            // ------------------------------------
            users.Add(new User 
            { 
                Id = 103, 
                PhoneNumber = "0333333103", 
                Email = "gv_khoi10@fpt.edu.vn",
                Password = "password123", 
                FullName = "Giáo viên bắt buộc 2",
                StudentId = "GVBB02",
                SubjectGroup = "Bắt buộc",
                ClassId = null
            });
            users.Add(new User 
            { 
                Id = 104, 
                PhoneNumber = "0333333104", 
                Email = "gv_khoi11@fpt.edu.vn",
                Password = "password123", 
                FullName = "Giáo viên tự nhiên 2",
                StudentId = "GVTN02",
                SubjectGroup = "Tự nhiên",
                ClassId = null
            });
            users.Add(new User 
            { 
                Id = 105, 
                PhoneNumber = "0333333105", 
                Email = "gv_khoi12@fpt.edu.vn",
                Password = "password123", 
                FullName = "Giáo viên xã hội 2",
                StudentId = "GVXH02",
                SubjectGroup = "Xã hội",
                ClassId = null
            });
            
            modelBuilder.Entity<User>().HasData(users);

            // Seed UserRoles
            var userRoles = new List<UserRole>();
            userRoles.Add(new UserRole { UserId = 1, RoleId = 1 }); // Admin is Admin
            
            for (int i = 3; i < userId; i++)
            {
                userRoles.Add(new UserRole { UserId = i, RoleId = 2 }); // Students
                userRoles.Add(new UserRole { UserId = i + 200, RoleId = 4 }); // Parents
            }

            // Roles for new teachers
            userRoles.Add(new UserRole { UserId = 100, RoleId = 3 });
            userRoles.Add(new UserRole { UserId = 101, RoleId = 3 });
            userRoles.Add(new UserRole { UserId = 102, RoleId = 3 });
            userRoles.Add(new UserRole { UserId = 103, RoleId = 3 });
            userRoles.Add(new UserRole { UserId = 104, RoleId = 3 });
            userRoles.Add(new UserRole { UserId = 105, RoleId = 3 });
            modelBuilder.Entity<UserRole>().HasData(userRoles);

            // ------------------------------------
            // Seed Subjects & TeacherSubjects
            // ------------------------------------
            var subjects = new List<Subject>();
            int subjectId = 1;

            var bbSubjects = new[] {
                ("TOAN", "Toán"), 
                ("NV", "Ngữ văn"), 
                ("NN1", "Ngoại ngữ 1 (Tiếng Anh)"), 
                ("LS", "Lịch sử"), 
                ("GDTC", "Giáo dục Thể chất"), 
                ("GDQPAN", "Giáo dục Quốc phòng và An ninh")
            };

            var tnSubjects = new[] {
                ("VL", "Vật lý"),
                ("HH", "Hóa học"),
                ("SH", "Sinh học")
            };

            var xhSubjects = new[] {
                ("DL", "Địa lý"),
                ("GDKTPL", "Giáo dục kinh tế và pháp luật")
            };

            var cnntSubjects = new[] {
                ("TH", "Tin học"),
                ("CN", "Công nghệ"),
                ("AN", "Âm nhạc"),
                ("MT", "Mỹ thuật")
            };

            var tsList = new List<TeacherSubject>();

            foreach (var g in grades)
            {
                int gradeTeacherId = g == 10 ? 103 : (g == 11 ? 104 : 105);
            
                // Bắt buộc
                foreach(var s in bbSubjects)
                {
                    subjects.Add(new Subject { Id = subjectId, Code = $"{s.Item1} {g}", Name = s.Item2, Grade = g, Group = "Bắt buộc" });
                    tsList.Add(new TeacherSubject { TeacherId = 100, SubjectId = subjectId });
                    tsList.Add(new TeacherSubject { TeacherId = gradeTeacherId, SubjectId = subjectId });
                    subjectId++;
                }

                // Tự nhiên
                foreach(var s in tnSubjects)
                {
                    subjects.Add(new Subject { Id = subjectId, Code = $"{s.Item1} {g}", Name = s.Item2, Grade = g, Group = "Lựa chọn (Tự nhiên)" });
                    tsList.Add(new TeacherSubject { TeacherId = 101, SubjectId = subjectId });
                    tsList.Add(new TeacherSubject { TeacherId = gradeTeacherId, SubjectId = subjectId });
                    subjectId++;
                }

                // Xã hội
                foreach(var s in xhSubjects)
                {
                    subjects.Add(new Subject { Id = subjectId, Code = $"{s.Item1} {g}", Name = s.Item2, Grade = g, Group = "Lựa chọn (Xã hội)" });
                    tsList.Add(new TeacherSubject { TeacherId = 102, SubjectId = subjectId });
                    tsList.Add(new TeacherSubject { TeacherId = gradeTeacherId, SubjectId = subjectId });
                    subjectId++;
                }
                
                // Công nghệ và Nghệ thuật
                foreach(var s in cnntSubjects)
                {
                    subjects.Add(new Subject { Id = subjectId, Code = $"{s.Item1} {g}", Name = s.Item2, Grade = g, Group = "Lựa chọn (Công nghệ & Nghệ thuật)" });
                    // Give these subjects to Teacher 100 as well for simplicity
                    tsList.Add(new TeacherSubject { TeacherId = 100, SubjectId = subjectId });
                    tsList.Add(new TeacherSubject { TeacherId = gradeTeacherId, SubjectId = subjectId });
                    subjectId++;
                }
            }

            modelBuilder.Entity<Subject>().HasData(subjects);
            modelBuilder.Entity<TeacherSubject>().HasData(tsList);

            // Seed Schedules
            modelBuilder.Entity<Schedule>().HasData(
                new Schedule { Id = 1, Date = new DateTime(2026, 6, 15), Slot = 1, RoomId = 1, SubjectCode = "TOAN 10", ClassId = 1, ClassSize = 30, TeacherId = 100, Status = "PRESENT" },
                new Schedule { Id = 2, Date = new DateTime(2026, 6, 15), Slot = 2, RoomId = 1, SubjectCode = "TOAN 10", ClassId = 1, ClassSize = 30, TeacherId = 100, Status = "PRESENT" },
                new Schedule { Id = 3, Date = new DateTime(2026, 6, 16), Slot = 1, RoomId = 1, SubjectCode = "TOAN 10", ClassId = 1, ClassSize = 30, TeacherId = 100, Status = "FUTURE" },
                new Schedule { Id = 4, Date = new DateTime(2026, 6, 17), Slot = 4, RoomId = 3, SubjectCode = "TOAN 10", ClassId = 1, ClassSize = 30, TeacherId = 100, Status = "FUTURE" }
            );

            // Seed Grades programmatically
            var gradesList = new List<Grade>();
            int gradeId = 1;

            // Helper for generating grades
            void AddGrades(int studentId, int classId, int subjectId, string year, double score) {
                gradesList.Add(new Grade { Id = gradeId++, StudentId = studentId, SubjectId = subjectId, ClassId = classId, AcademicYear = year, Semester = 1, AttendanceScore = score, OralScore1 = score, OralScore2 = score, FifteenMinScore1 = score, FifteenMinScore2 = score, MidtermScore = score, FinalScore = score });
                // gradesList.Add(new Grade { Id = gradeId++, StudentId = studentId, SubjectId = subjectId, ClassId = classId, AcademicYear = year, Semester = 2, AttendanceScore = score, OralScore1 = score, OralScore2 = score, FifteenMinScore1 = score, FifteenMinScore2 = score, MidtermScore = score, FinalScore = score });
            }

            // Student 3 (10A) - Xuất sắc in Grade 10 (2023-2024)
            for (int i = 1; i <= 12; i++) {
                AddGrades(3, 1, i, "2023-2024", 9.5); // Score 9.5 => Xuất sắc
            }

            // Student 21 (12A) - 3 years
            // Year 10 (2023-2024): Đạt (Score 5.5) - Học lớp 10A (K1) có ClassId = 10
            for (int i = 1; i <= 12; i++) {
                AddGrades(21, 10, i, "2023-2024", 5.5);
            }
            // Year 11 (2024-2025): Khá (Score 7.0) - Học lớp 11A (K1) có ClassId = 11
            for (int i = 16; i <= 27; i++) {
                AddGrades(21, 11, i, "2024-2025", 7.0);
            }
            // Year 12 (2025-2026): Giỏi (Score 8.5)
            for (int i = 31; i <= 42; i++) {
                AddGrades(21, 7, i, "2025-2026", 8.5);
            }

            modelBuilder.Entity<Grade>().HasData(gradesList);

            // Seed Clubs
            modelBuilder.Entity<Club>().HasData(
                new Club { Id = 1, Name = "CLB Âm nhạc", Code = "MC", Type = "Nghệ thuật & Văn hóa", Status = "HOẠT ĐỘNG", PresidentId = 3 },
                new Club { Id = 2, Name = "CLB Bóng rổ", Code = "BC", Type = "Thể thao", Status = "HOẠT ĐỘNG", PresidentId = 4 },
                new Club { Id = 3, Name = "CLB Lập trình & AI", Code = "IT", Type = "Học thuật", Status = "TẠM NGỪNG", PresidentId = 5 }
            );

            // Seed Club Members (approx. members)
            var clubMembers = new List<ClubMember>();
            for(int i = 3; i <= 29; i++) {
                if (i % 2 == 0) clubMembers.Add(new ClubMember { ClubId = 1, UserId = i, JoinedDate = DateTime.UtcNow });
                if (i % 3 == 0) clubMembers.Add(new ClubMember { ClubId = 2, UserId = i, JoinedDate = DateTime.UtcNow });
                if (i % 4 == 0) clubMembers.Add(new ClubMember { ClubId = 3, UserId = i, JoinedDate = DateTime.UtcNow });
            }
            modelBuilder.Entity<ClubMember>().HasData(clubMembers);

        }
    }
}
