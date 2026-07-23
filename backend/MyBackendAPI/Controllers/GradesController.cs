using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClosedXML.Excel;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.Models;
using System.Security.Claims;
using System.Linq;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GradesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/grades/my-grades
        // For Students
        [HttpGet("my-grades")]
        [Authorize(Roles = "Student,Parent")]
        public async Task<IActionResult> GetMyGrades()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return Unauthorized();

            var currentUser = await _context.Users.FindAsync(userId);
            int targetStudentId = userId;
            if (currentUser != null && currentUser.ChildId.HasValue)
            {
                targetStudentId = currentUser.ChildId.Value;
            }

            var grades = await _context.Grades
                .Include(g => g.Subject)
                .Where(g => g.StudentId == targetStudentId)
                .Select(g => new {
                    g.Id,
                    SubjectName = g.Subject.Name,
                    ClassId = g.ClassId,
                    g.AcademicYear,
                    g.Semester,
                    g.AttendanceScore,
                    g.OralScore1,
                    g.OralScore2,
                    g.FifteenMinScore1,
                    g.FifteenMinScore2,
                    g.MidtermScore,
                    g.FinalScore
                })
                .ToListAsync();

            return Ok(grades);
        }

        // GET: api/grades/class/{classId}
        // For Teachers and Admins to view grades of a class
        [HttpGet("class/{classId}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> GetClassGrades(int classId)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
                return Unauthorized();
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var c = await _context.Classes.FindAsync(classId);
            if (c == null) return NotFound("Class not found");

            var gradesQuery = _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Where(g => g.ClassId == classId);

            if (userRole == "Teacher" && c.HomeroomTeacherId != userId)
            {
                // Only return subjects taught by this teacher for this specific class
                var scheduledSubjectCodes = await _context.Schedules
                    .Where(s => s.TeacherId == userId && s.ClassId == classId)
                    .Select(s => s.SubjectCode)
                    .Distinct()
                    .ToListAsync();

                var scheduledSubjectIds = await _context.Subjects
                    .Where(sub => scheduledSubjectCodes.Contains(sub.Code))
                    .Select(sub => sub.Id)
                    .ToListAsync();
                
                gradesQuery = gradesQuery.Where(g => scheduledSubjectIds.Contains(g.SubjectId));
            }

            var grades = await gradesQuery
                .Select(g => new {
                    g.Id,
                    StudentId = g.StudentId,
                    StudentName = g.Student.FullName,
                    SubjectId = g.SubjectId,
                    SubjectName = g.Subject.Name,
                    ClassId = g.ClassId,
                    g.AcademicYear,
                    g.Semester,
                    g.AttendanceScore,
                    g.OralScore1,
                    g.OralScore2,
                    g.FifteenMinScore1,
                    g.FifteenMinScore2,
                    g.MidtermScore,
                    g.FinalScore,
                    IsGradeLocked = c.IsGradeLocked
                })
                .ToListAsync();

            return Ok(grades);
        }

        // GET: api/grades/class/{classId}/my-subjects
        // For Teachers to get subjects they teach for a specific class
        [HttpGet("class/{classId}/my-subjects")]
        [Authorize(Roles = "Teacher, Admin")]
        public async Task<IActionResult> GetMySubjectsForClass(int classId)
        {
            var userIdStr = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdStr, out int userId)) return Unauthorized();
            return await GetSubjectsInternal(userId, classId);
        }

        [HttpGet("test-subjects/{userId}/{classId}")]
        [AllowAnonymous]
        public async Task<IActionResult> TestSubjects(int userId, int classId)
        {
            return await GetSubjectsInternal(userId, classId);
        }

        private async Task<IActionResult> GetSubjectsInternal(int userId, int classId)
        {
            var scheduledSubjectCodes = await _context.Schedules
                .Where(s => s.TeacherId == userId && s.ClassId == classId)
                .Select(s => s.SubjectCode)
                .Distinct()
                .ToListAsync();

            var subjects = await _context.Subjects
                .Where(sub => scheduledSubjectCodes.Contains(sub.Code))
                .Select(s => new {
                    s.Id,
                    s.Code,
                    s.Name,
                    s.Group
                })
                .ToListAsync();

            return Ok(subjects);
        }

        // PUT: api/grades/class/{classId}/lock
        // For Admin to lock/unlock grades of a class
        [HttpPut("class/{classId}/lock")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleLockGrade(int classId, [FromBody] bool isLocked)
        {
            var cls = await _context.Classes.FindAsync(classId);
            if (cls == null) return NotFound("Class not found");

            cls.IsGradeLocked = isLocked;
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Sổ điểm đã được {(isLocked ? "khóa" : "mở khóa")}." });
        }

        // PUT: api/grades/lock-all
        // For Admin to lock/unlock grades of ALL classes
        [HttpPut("lock-all")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleLockAllGrades([FromBody] bool isLocked)
        {
            var classes = await _context.Classes.ToListAsync();
            foreach (var cls in classes)
            {
                cls.IsGradeLocked = isLocked;
            }
            await _context.SaveChangesAsync();

            return Ok(new { message = $"Sổ điểm toàn trường đã được {(isLocked ? "khóa" : "mở khóa")}." });
        }

        // POST: api/grades
        // For Web Portal to submit grades
        [HttpPost]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> UpdateGrade([FromBody] GradeDto dto)
        {
            var cls = await _context.Classes.FindAsync(dto.ClassId);
            if (cls == null) return NotFound("Class not found");
            if (cls.IsGradeLocked && !User.IsInRole("Admin")) return BadRequest("Sổ điểm đã bị khóa, không thể nhập/sửa.");

            var grade = await _context.Grades.FirstOrDefaultAsync(g => g.StudentId == dto.StudentId && g.SubjectId == dto.SubjectId && g.Semester == dto.Semester);
            if (grade == null)
            {
                grade = new Grade
                {
                    StudentId = dto.StudentId,
                    SubjectId = dto.SubjectId,
                    ClassId = dto.ClassId,
                    Semester = dto.Semester,
                    AcademicYear = cls.StartYear != 0 ? $"{cls.StartYear}-{cls.StartYear+1}" : "2025-2026" // Fallback if StartYear is empty
                };
                _context.Grades.Add(grade);
            }

            grade.AttendanceScore = dto.AttendanceScore;
            grade.OralScore1 = dto.OralScore1;
            grade.OralScore2 = dto.OralScore2;
            grade.FifteenMinScore1 = dto.FifteenMinScore1;
            grade.FifteenMinScore2 = dto.FifteenMinScore2;
            grade.MidtermScore = dto.MidtermScore;
            grade.FinalScore = dto.FinalScore;

            await _context.SaveChangesAsync();
            return Ok(grade);
        }

        // GET: api/grades/all
        // For Admin to get all grades
        [HttpGet("all")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllGrades()
        {
            var grades = await _context.Grades
                .Include(g => g.Student)
                .Include(g => g.Subject)
                .Select(g => new {
                    g.Id,
                    StudentId = g.StudentId,
                    StudentName = g.Student.FullName,
                    SubjectId = g.SubjectId,
                    SubjectName = g.Subject.Name,
                    ClassId = g.ClassId,
                    g.AcademicYear,
                    g.Semester,
                    g.AttendanceScore,
                    g.OralScore1,
                    g.OralScore2,
                    g.FifteenMinScore1,
                    g.FifteenMinScore2,
                    g.MidtermScore,
                    g.FinalScore,
                    IsGradeLocked = false // Assuming all grades might have different locks, or we omit it
                })
                .ToListAsync();

            return Ok(grades);
        }

        // DELETE: api/grades/student/{studentId}
        [HttpDelete("student/{studentId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteStudentGrades(int studentId)
        {
            var grades = await _context.Grades.Where(g => g.StudentId == studentId).ToListAsync();
            _context.Grades.RemoveRange(grades);
            await _context.SaveChangesAsync();

            return Ok(new { message = "All grades for the student have been deleted." });
        }
        private double? ParseDouble(IXLCell cell)
        {
            if (cell.IsEmpty()) return null;
            if (double.TryParse(cell.Value.ToString(), out double res))
            {
                if (res > 10 || res < 0) throw new InvalidOperationException($"Điểm không hợp lệ: {res}. Điểm phải từ 0 đến 10.");
                return res;
            }
            return null;
        }

        // GET: api/grades/export/{classId}
        [HttpGet("export/{classId}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> ExportExcel(int classId, [FromQuery] int subjectId, [FromQuery] string academicYear = "2025-2026", [FromQuery] int? studentId = null)
        {
            var cls = await _context.Classes.FindAsync(classId);
            if (cls == null) return NotFound("Class not found");

            var subject = await _context.Subjects.FindAsync(subjectId);
            if (subject == null) return NotFound("Subject not found");

            var studentsQuery = _context.Users
                .Where(u => u.ClassId == classId && u.UserRoles.Any(ur => ur.Role.RoleName == "Student"));
            
            if (studentId.HasValue)
            {
                studentsQuery = studentsQuery.Where(u => u.Id == studentId.Value);
            }

            var students = await studentsQuery.OrderBy(u => u.FullName).ToListAsync();

            var existingGrades = await _context.Grades
                .Where(g => g.ClassId == classId && g.SubjectId == subjectId && g.AcademicYear == academicYear)
                .ToListAsync();

            var gradesByStudent = existingGrades
                .GroupBy(g => g.StudentId)
                .ToDictionary(g => g.Key, g => g.ToList());

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("DiemSo");

            worksheet.Cell(1, 1).Value = "STT";
            worksheet.Cell(1, 2).Value = "Mã HS";
            worksheet.Cell(1, 3).Value = "Họ và tên";
            worksheet.Cell(1, 4).Value = "HK1 Điểm CC";
            worksheet.Cell(1, 5).Value = "HK1 Miệng 1";
            worksheet.Cell(1, 6).Value = "HK1 Miệng 2";
            worksheet.Cell(1, 7).Value = "HK1 15 Phút 1";
            worksheet.Cell(1, 8).Value = "HK1 15 Phút 2";
            worksheet.Cell(1, 9).Value = "HK1 Giữa kỳ";
            worksheet.Cell(1, 10).Value = "HK1 Cuối kỳ";

            worksheet.Cell(1, 11).Value = "HK2 Điểm CC";
            worksheet.Cell(1, 12).Value = "HK2 Miệng 1";
            worksheet.Cell(1, 13).Value = "HK2 Miệng 2";
            worksheet.Cell(1, 14).Value = "HK2 15 Phút 1";
            worksheet.Cell(1, 15).Value = "HK2 15 Phút 2";
            worksheet.Cell(1, 16).Value = "HK2 Giữa kỳ";
            worksheet.Cell(1, 17).Value = "HK2 Cuối kỳ";
            
            worksheet.Range("A1:Q1").Style.Font.Bold = true;
            worksheet.Range("A1:Q1").Style.Fill.BackgroundColor = XLColor.LightGray;

            int row = 2;
            foreach (var student in students)
            {
                worksheet.Cell(row, 1).Value = row - 1;
                worksheet.Cell(row, 2).Value = student.Id;
                worksheet.Cell(row, 3).Value = student.FullName;
                
                if (gradesByStudent.TryGetValue(student.Id, out var studentGrades))
                {
                    var hk1 = studentGrades.FirstOrDefault(g => g.Semester == 1);
                    if (hk1 != null)
                    {
                        if (hk1.AttendanceScore.HasValue) worksheet.Cell(row, 4).Value = hk1.AttendanceScore.Value;
                        if (hk1.OralScore1.HasValue) worksheet.Cell(row, 5).Value = hk1.OralScore1.Value;
                        if (hk1.OralScore2.HasValue) worksheet.Cell(row, 6).Value = hk1.OralScore2.Value;
                        if (hk1.FifteenMinScore1.HasValue) worksheet.Cell(row, 7).Value = hk1.FifteenMinScore1.Value;
                        if (hk1.FifteenMinScore2.HasValue) worksheet.Cell(row, 8).Value = hk1.FifteenMinScore2.Value;
                        if (hk1.MidtermScore.HasValue) worksheet.Cell(row, 9).Value = hk1.MidtermScore.Value;
                        if (hk1.FinalScore.HasValue) worksheet.Cell(row, 10).Value = hk1.FinalScore.Value;
                    }

                    var hk2 = studentGrades.FirstOrDefault(g => g.Semester == 2);
                    if (hk2 != null)
                    {
                        if (hk2.AttendanceScore.HasValue) worksheet.Cell(row, 11).Value = hk2.AttendanceScore.Value;
                        if (hk2.OralScore1.HasValue) worksheet.Cell(row, 12).Value = hk2.OralScore1.Value;
                        if (hk2.OralScore2.HasValue) worksheet.Cell(row, 13).Value = hk2.OralScore2.Value;
                        if (hk2.FifteenMinScore1.HasValue) worksheet.Cell(row, 14).Value = hk2.FifteenMinScore1.Value;
                        if (hk2.FifteenMinScore2.HasValue) worksheet.Cell(row, 15).Value = hk2.FifteenMinScore2.Value;
                        if (hk2.MidtermScore.HasValue) worksheet.Cell(row, 16).Value = hk2.MidtermScore.Value;
                        if (hk2.FinalScore.HasValue) worksheet.Cell(row, 17).Value = hk2.FinalScore.Value;
                    }
                }
                row++;
            }

            worksheet.Columns().AdjustToContents();

            using var stream = new System.IO.MemoryStream();
            workbook.SaveAs(stream);
            var content = stream.ToArray();

            return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Diem_{cls.Name}_{subject.Name}_CaNam.xlsx");
        }

        // POST: api/grades/import/{classId}
        [HttpPost("import/{classId}")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<IActionResult> ImportExcel(int classId, [FromQuery] int subjectId, [FromQuery] string academicYear = "2025-2026", IFormFile file = null)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded");

            var cls = await _context.Classes.FindAsync(classId);
            if (cls == null) return NotFound("Class not found");
            if (cls.IsGradeLocked && !User.IsInRole("Admin")) return BadRequest("Sổ điểm đã bị khóa");

            using var stream = new System.IO.MemoryStream();
            await file.CopyToAsync(stream);
            stream.Position = 0;

            using var workbook = new XLWorkbook(stream);
            var worksheet = workbook.Worksheet(1);
            var rows = worksheet.RangeUsed().RowsUsed().Skip(1); // Skip header

            var existingGrades = await _context.Grades
                .Where(g => g.ClassId == classId && g.SubjectId == subjectId && g.AcademicYear == academicYear)
                .ToListAsync();

            var gradesByStudent = existingGrades
                .GroupBy(g => g.StudentId)
                .ToDictionary(g => g.Key, g => g.ToList());

            try
            {
                foreach (var row in rows)
            {
                if (!int.TryParse(row.Cell(2).Value.ToString(), out int studentId)) continue;

                gradesByStudent.TryGetValue(studentId, out var studentGrades);
                studentGrades ??= new List<Grade>();

                var hk1 = studentGrades.FirstOrDefault(g => g.Semester == 1);
                var hk2 = studentGrades.FirstOrDefault(g => g.Semester == 2);

                bool hasHk1 = !row.Cell(4).IsEmpty() || !row.Cell(5).IsEmpty() || !row.Cell(6).IsEmpty() || !row.Cell(7).IsEmpty() || !row.Cell(8).IsEmpty() || !row.Cell(9).IsEmpty() || !row.Cell(10).IsEmpty();
                bool hasHk2 = !row.Cell(11).IsEmpty() || !row.Cell(12).IsEmpty() || !row.Cell(13).IsEmpty() || !row.Cell(14).IsEmpty() || !row.Cell(15).IsEmpty() || !row.Cell(16).IsEmpty() || !row.Cell(17).IsEmpty();

                if (hasHk1)
                {
                    if (hk1 == null)
                    {
                        hk1 = new Grade
                        {
                            StudentId = studentId,
                            ClassId = classId,
                            SubjectId = subjectId,
                            AcademicYear = academicYear,
                            Semester = 1
                        };
                        _context.Grades.Add(hk1);
                    }
                    hk1.AttendanceScore = ParseDouble(row.Cell(4));
                    hk1.OralScore1 = ParseDouble(row.Cell(5));
                    hk1.OralScore2 = ParseDouble(row.Cell(6));
                    hk1.FifteenMinScore1 = ParseDouble(row.Cell(7));
                    hk1.FifteenMinScore2 = ParseDouble(row.Cell(8));
                    hk1.MidtermScore = ParseDouble(row.Cell(9));
                    hk1.FinalScore = ParseDouble(row.Cell(10));
                }
                else if (hk1 != null)
                {
                    _context.Grades.Remove(hk1);
                }

                if (hasHk2)
                {
                    if (hk2 == null)
                    {
                        hk2 = new Grade
                        {
                            StudentId = studentId,
                            ClassId = classId,
                            SubjectId = subjectId,
                            AcademicYear = academicYear,
                            Semester = 2
                        };
                        _context.Grades.Add(hk2);
                    }
                    hk2.AttendanceScore = ParseDouble(row.Cell(11));
                    hk2.OralScore1 = ParseDouble(row.Cell(12));
                    hk2.OralScore2 = ParseDouble(row.Cell(13));
                    hk2.FifteenMinScore1 = ParseDouble(row.Cell(14));
                    hk2.FifteenMinScore2 = ParseDouble(row.Cell(15));
                    hk2.MidtermScore = ParseDouble(row.Cell(16));
                    hk2.FinalScore = ParseDouble(row.Cell(17));
                }
                else if (hk2 != null)
                {
                    _context.Grades.Remove(hk2);
                }
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Import success" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    public class GradeDto
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public int ClassId { get; set; }
        public int Semester { get; set; }
        public double? AttendanceScore { get; set; }
        public double? OralScore1 { get; set; }
        public double? OralScore2 { get; set; }
        public double? FifteenMinScore1 { get; set; }
        public double? FifteenMinScore2 { get; set; }
        public double? MidtermScore { get; set; }
        public double? FinalScore { get; set; }
    }
}
