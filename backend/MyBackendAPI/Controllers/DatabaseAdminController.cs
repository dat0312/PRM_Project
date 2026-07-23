using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatabaseAdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DatabaseAdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("cleanup-promotion")]
        [AllowAnonymous]
        public async Task<IActionResult> CleanupAndPromote()
        {
            // 1. Get all students
            var students = await _context.Users
                .Include(u => u.UserRoles).ThenInclude(ur => ur.Role)
                .Include(u => u.Class)
                .Where(u => u.UserRoles.Any(ur => ur.Role.RoleName == "Student") && u.ClassId != null)
                .ToListAsync();

            var subjects = await _context.Subjects.ToListAsync();
            var allClasses = await _context.Classes.ToListAsync();

            int gradesAdded = 0;
            int studentsPromoted = 0;

            foreach (var student in students)
            {
                var currentClass = student.Class;
                if (currentClass == null) continue;

                // Handle K1 students (should be Grade 12 now)
                if (currentClass.Cohort == "K1")
                {
                    if (currentClass.Grade < 12) {
                        var class12Name = currentClass.Name.Replace("10", "").Replace("11", "");
                        var class12 = await GetOrCreateClass(12, class12Name, "K1", 2023);
                        student.ClassId = class12.Id;
                        studentsPromoted++;
                        currentClass = class12;
                    }

                    // Always ensure Grade 10 and 11 history exists!
                    var class10Name = currentClass.Name.Replace("12", "");
                    var class10 = await GetOrCreateClass(10, class10Name, "K1", 2023);
                    gradesAdded += await EnsureDummyGrades(student.Id, class10.Id, subjects, "2023-2024");
                    
                    var class11Name = currentClass.Name.Replace("12", "");
                    var class11 = await GetOrCreateClass(11, class11Name, "K1", 2023);
                    gradesAdded += await EnsureDummyGrades(student.Id, class11.Id, subjects, "2024-2025");
                }
                // Handle K2 students (should be Grade 11 now)
                else if (currentClass.Cohort == "K2")
                {
                    if (currentClass.Grade < 11) {
                        var class11Name = currentClass.Name.Replace("10", "");
                        var class11 = await GetOrCreateClass(11, class11Name, "K2", 2024);
                        student.ClassId = class11.Id;
                        studentsPromoted++;
                        currentClass = class11;
                    }

                    // Always ensure Grade 10 history exists
                    var class10Name = currentClass.Name.Replace("11", "");
                    var class10 = await GetOrCreateClass(10, class10Name, "K2", 2024);
                    gradesAdded += await EnsureDummyGrades(student.Id, class10.Id, subjects, "2024-2025");
                }
            }

            // Lock all old classes for K1 (Grade 10, 11) and K2 (Grade 10)
            var oldClasses = await _context.Classes
                .Where(c => (c.Cohort == "K1" && c.Grade < 12) || (c.Cohort == "K2" && c.Grade < 11))
                .ToListAsync();

            foreach (var cls in oldClasses)
            {
                cls.IsGradeLocked = true;
            }

            await _context.SaveChangesAsync();

            return Ok(new
            {
                Message = "Cleanup & Promotion Completed Successfully!",
                TotalStudentsFound = students.Count,
                StudentsInK1 = students.Count(s => s.Class != null && s.Class.Cohort == "K1"),
                StudentsInK2 = students.Count(s => s.Class != null && s.Class.Cohort == "K2"),
                StudentsPromoted = studentsPromoted,
                DummyGradesAdded = gradesAdded,
                OldClassesLocked = oldClasses.Count
            });
        }

        private async Task<Class> GetOrCreateClass(int grade, string suffixName, string cohort, int startYear)
        {
            var className = suffixName; // The suffix already, e.g., "A"
            if (className.StartsWith(grade.ToString())) {
                className = className.Substring(grade.ToString().Length);
            }

            var existingClass = await _context.Classes
                .FirstOrDefaultAsync(c => c.Grade == grade && c.Cohort == cohort && c.Name == className);

            if (existingClass != null) return existingClass;

            var newClass = new Class
            {
                Name = className,
                Grade = grade,
                Cohort = cohort,
                StartYear = startYear,
                IsGradeLocked = false
            };
            _context.Classes.Add(newClass);
            await _context.SaveChangesAsync();
            return newClass;
        }

        private async Task<int> EnsureDummyGrades(int studentId, int classId, List<Subject> subjects, string academicYear)
        {
            int added = 0;
            // Get existing grades for this student and class
            var existingGrades = await _context.Grades
                .Where(g => g.StudentId == studentId && g.ClassId == classId && g.AcademicYear == academicYear)
                .ToListAsync();

            foreach (var subject in subjects)
            {
                // Ensure Semester 1
                if (!existingGrades.Any(g => g.SubjectId == subject.Id && g.Semester == 1))
                {
                    _context.Grades.Add(new Grade
                    {
                        StudentId = studentId,
                        SubjectId = subject.Id,
                        ClassId = classId,
                        AcademicYear = academicYear,
                        Semester = 1,
                        AttendanceScore = 8.5,
                        OralScore1 = 8.0,
                        OralScore2 = 8.0,
                        FifteenMinScore1 = 8.0,
                        FifteenMinScore2 = 8.5,
                        MidtermScore = 8.0,
                        FinalScore = 8.0
                    });
                    added++;
                }

                // Ensure Semester 2
                if (!existingGrades.Any(g => g.SubjectId == subject.Id && g.Semester == 2))
                {
                    _context.Grades.Add(new Grade
                    {
                        StudentId = studentId,
                        SubjectId = subject.Id,
                        ClassId = classId,
                        AcademicYear = academicYear,
                        Semester = 2,
                        AttendanceScore = 8.5,
                        OralScore1 = 8.0,
                        OralScore2 = 8.0,
                        FifteenMinScore1 = 8.0,
                        FifteenMinScore2 = 8.5,
                        MidtermScore = 8.5,
                        FinalScore = 8.5
                    });
                    added++;
                }
            }
            return added;
        }

        [HttpGet("seed-class")]
        [AllowAnonymous]
        public async Task<IActionResult> SeedClass([FromQuery] string name = "A", [FromQuery] string cohort = "K3", [FromQuery] string gradeLevel = "10")
        {
            var clazz = await _context.Classes.FirstOrDefaultAsync(c => c.Name == name && c.Cohort == cohort);
            if (clazz == null) return NotFound($"Class {name} {cohort} not found");
            var classId = clazz.Id;

            var academicYear = "2025-2026";
            
            var existingGrades = await _context.Grades.Where(g => g.ClassId == classId).ToListAsync();
            _context.Grades.RemoveRange(existingGrades);

            var students = await _context.Users
                .Where(u => u.ClassId == classId && u.UserRoles.Any(ur => ur.Role.RoleName == "Student"))
                .ToListAsync();

            var subjects = await _context.Subjects.Where(s => s.Code.Contains($" {gradeLevel}")).ToListAsync();
            
            int studentIdx = 0;
            var basescores = new double[] { 9.5, 8.5, 7.0, 5.5, 4.0 };
            foreach (var student in students)
            {
                var baseScore = basescores[studentIdx % basescores.Length];
                foreach (var subject in subjects)
                {
                    for (int semester = 1; semester <= 2; semester++)
                    {
                        _context.Grades.Add(new Grade
                        {
                            StudentId = student.Id,
                            SubjectId = subject.Id,
                            ClassId = classId,
                            AcademicYear = academicYear,
                            Semester = semester,
                            AttendanceScore = baseScore,
                            OralScore1 = baseScore,
                            OralScore2 = baseScore,
                            FifteenMinScore1 = baseScore,
                            FifteenMinScore2 = baseScore,
                            MidtermScore = baseScore,
                            FinalScore = baseScore
                        });
                    }
                }
                studentIdx++;
            }

            var existingSchedules = await _context.Schedules.Where(s => s.ClassId == classId).ToListAsync();
            _context.Schedules.RemoveRange(existingSchedules);

            var room = await _context.Rooms.FirstOrDefaultAsync();
            int roomId = room != null ? room.Id : 1;
            
            var teacherRole = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == "Teacher");
            int teacherRoleId = teacherRole != null ? teacherRole.Id : 2;

            var teacherSubjects = await _context.TeacherSubjects.ToListAsync();
            
            // Automatically insert missing teachers
            foreach (var sub in subjects)
            {
                var pt = teacherSubjects.Where(ts => ts.SubjectId == sub.Id).ToList();
                if (!pt.Any())
                {
                    var newTeacher = new User
                    {
                        FullName = "Giáo viên " + sub.Name,
                        Email = "gv_" + sub.Code.ToLower().Replace(" ", "") + "@school.edu.vn",
                        Password = BCrypt.Net.BCrypt.HashPassword("123456"),
                        SubjectGroup = "Chung",
                        PhoneNumber = "09" + Guid.NewGuid().ToString("N").Substring(0, 8)
                    };
                    _context.Users.Add(newTeacher);
                    await _context.SaveChangesAsync();

                    _context.UserRoles.Add(new UserRole { UserId = newTeacher.Id, RoleId = teacherRoleId });
                    var newTs = new TeacherSubject { TeacherId = newTeacher.Id, SubjectId = sub.Id };
                    _context.TeacherSubjects.Add(newTs);
                    await _context.SaveChangesAsync();
                    
                    teacherSubjects.Add(newTs);
                }
            }

            var startDate = new System.DateTime(2026, 7, 20); // A Monday in July 2026
            int subjectIdx = 0;
            var newSchedules = new List<Schedule>();

            for (int week = 0; week < 5; week++)
            {
                for (int day = 0; day < 6; day++) // Mon to Sat
                {
                    var currentDate = startDate.AddDays(week * 7 + day);
                    for (int slot = 1; slot <= 4; slot++)
                    {
                        var subject = subjects[subjectIdx % subjects.Count];
                        
                        var possibleTeachers = teacherSubjects.Where(ts => ts.SubjectId == subject.Id).Select(ts => ts.TeacherId).ToList();
                        int assignedTeacherId = possibleTeachers[(week * 10 + day * 4 + slot) % possibleTeachers.Count];
                        
                        newSchedules.Add(new Schedule
                        {
                            Date = currentDate,
                            Slot = slot,
                            RoomId = roomId,
                            SubjectCode = subject.Code,
                            ClassId = classId,
                            TeacherId = assignedTeacherId,
                            Status = "FUTURE"
                        });
                        
                        subjectIdx++;
                    }
                }
            }
            
            _context.Schedules.AddRange(newSchedules);
            await _context.SaveChangesAsync();
            
            return Ok(new {
                Message = "Seeded successfully",
                GradesAdded = students.Count * subjects.Count * 2,
                SchedulesAdded = newSchedules.Count
            });
        }
    }
}
