using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("teachers")]
        public async Task<IActionResult> GetTeachers()
        {
            // Assuming Teacher has RoleId = 3 (as seen in seeded DB)
            var teachers = await _context.Users
                .Where(u => u.UserRoles.Any(ur => ur.Role.RoleName == "Teacher"))
                .Select(u => new
                {
                    u.Id,
                    u.FullName,
                    u.Email
                })
                .ToListAsync();

            return Ok(teachers);
        }

        [HttpGet("search-email")]
        [AllowAnonymous]
        public async Task<IActionResult> SearchEmail([FromQuery] string q)
        {
            if (string.IsNullOrWhiteSpace(q) || q.Length < 2)
            {
                return Ok(new List<object>());
            }

            var users = await _context.Users
                .Where(u => u.Email.Contains(q))
                .Select(u => new {
                    u.Id,
                    u.Email,
                    u.FullName
                })
                .Take(10)
                .ToListAsync();

            return Ok(users);
        }

        [HttpGet("users")]
        [AllowAnonymous]
        public async Task<IActionResult> GetUsers()
        {
            var classes = await _context.Classes.ToListAsync();
            var users = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Include(u => u.Class)
                .Include(u => u.TeacherSubjects)
                    .ThenInclude(ts => ts.Subject)
                .Where(u => !u.UserRoles.Any(ur => ur.Role.RoleName == "Admin"))
                .ToListAsync();

            var result = users.Select(u => {
                var isTeacher = u.UserRoles.Any(ur => ur.Role.RoleName == "Teacher");
                var homeroomClass = classes.FirstOrDefault(c => c.HomeroomTeacherId == u.Id);
                var activeClass = isTeacher ? homeroomClass : u.Class;

                return new
                {
                    Id = u.Id,
                    Code = u.StudentId ?? "TC-" + u.Id.ToString(), // StudentId or TeacherCode
                    Name = u.FullName,
                    PhoneNumber = u.PhoneNumber,
                    Email = u.Email,
                    Roles = u.UserRoles.Select(ur => ur.Role.RoleName).ToList(),
                    Grade = activeClass != null ? "Khối " + activeClass.Grade.ToString() : "-",
                    ClassName = activeClass != null ? 
                        (activeClass.Name.StartsWith(activeClass.Grade.ToString()) ? activeClass.Name : $"{activeClass.Grade}{activeClass.Name}") 
                        : "-",
                    Cohort = activeClass != null ? activeClass.Cohort : "-",
                    ClassId = activeClass?.Id,
                    SubjectGroup = u.SubjectGroup,
                    Subjects = u.TeacherSubjects.Select(ts => ts.Subject.Name).ToList(),
                    SubjectIds = u.TeacherSubjects.Select(ts => ts.SubjectId).ToList()
                };
            }).ToList();

            return Ok(result);
        }

        [HttpPost("add")]
        [AllowAnonymous] // Assuming admin token is needed in real app, but for now allow
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.PhoneNumber == dto.PhoneNumber))
                return BadRequest(new { message = "Số điện thoại đã tồn tại." });

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { message = "Email đã tồn tại." });

            var user = new Models.User
            {
                FullName = dto.FullName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                Password = "password123", // Default password
                ClassId = dto.Role == "Teacher" ? null : dto.ClassId,
                SubjectGroup = dto.Role == "Teacher" ? dto.SubjectGroup : null
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync(); // Save to get the ID

            if (dto.Role == "Teacher" && dto.SubjectIds != null && dto.SubjectIds.Any())
            {
                foreach (var sid in dto.SubjectIds)
                {
                    _context.TeacherSubjects.Add(new Models.TeacherSubject
                    {
                        TeacherId = user.Id,
                        SubjectId = sid
                    });
                }
            }

            // Generate StudentId based on newly generated ID
            if (dto.Role == "Student")
            {
                user.StudentId = $"STU{user.Id.ToString("D5")}";
            }
            else if (dto.Role == "Teacher")
            {
                if (dto.SubjectGroup == "Bắt buộc") user.StudentId = $"GVBB{user.Id.ToString("D2")}";
                else if (dto.SubjectGroup == "Tự nhiên") user.StudentId = $"GVTN{user.Id.ToString("D2")}";
                else if (dto.SubjectGroup == "Xã hội") user.StudentId = $"GVXH{user.Id.ToString("D2")}";
                else user.StudentId = $"GVXX{user.Id.ToString("D2")}";
            }

            // Assign role
            var roleEntity = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == dto.Role);
            if (roleEntity != null)
            {
                _context.UserRoles.Add(new Models.UserRole
                {
                    UserId = user.Id,
                    RoleId = roleEntity.Id
                });
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Tạo người dùng thành công", id = user.Id });
        }

        [HttpPut("edit/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateDto dto)
        {
            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .Include(u => u.TeacherSubjects)
                .FirstOrDefaultAsync(u => u.Id == id);
                
            if (user == null)
                return NotFound(new { message = "Không tìm thấy người dùng." });

            user.FullName = dto.FullName;
            user.ClassId = dto.Role == "Teacher" ? null : dto.ClassId;
            user.SubjectGroup = dto.Role == "Teacher" ? dto.SubjectGroup : null;

            if (dto.Role == "Teacher")
            {
                // Update Homeroom assignment
                var currentHomeroomClass = await _context.Classes.FirstOrDefaultAsync(c => c.HomeroomTeacherId == user.Id);
                if (currentHomeroomClass?.Id != dto.ClassId)
                {
                    if (currentHomeroomClass != null)
                    {
                        currentHomeroomClass.HomeroomTeacherId = null;
                    }
                    if (dto.ClassId.HasValue)
                    {
                        var newHomeroomClass = await _context.Classes.FindAsync(dto.ClassId.Value);
                        if (newHomeroomClass != null)
                        {
                            newHomeroomClass.HomeroomTeacherId = user.Id;
                        }
                    }
                }

                _context.TeacherSubjects.RemoveRange(user.TeacherSubjects);
                if (dto.SubjectIds != null && dto.SubjectIds.Any())
                {
                    foreach (var sid in dto.SubjectIds)
                    {
                        _context.TeacherSubjects.Add(new Models.TeacherSubject
                        {
                            TeacherId = user.Id,
                            SubjectId = sid
                        });
                    }
                }
            }

            // Update role if changed
            if (!user.UserRoles.Any(ur => ur.Role.RoleName == dto.Role))
            {
                _context.UserRoles.RemoveRange(user.UserRoles);
                var roleEntity = await _context.Roles.FirstOrDefaultAsync(r => r.RoleName == dto.Role);
                if (roleEntity != null)
                {
                    _context.UserRoles.Add(new Models.UserRole
                    {
                        UserId = user.Id,
                        RoleId = roleEntity.Id
                    });
                }
                
                // Adjust student id logic
                if (dto.Role == "Student" && user.StudentId == null)
                    user.StudentId = $"STU{user.Id.ToString("D5")}";
                else if (dto.Role == "Teacher")
                    user.StudentId = null;
            }

            await _context.SaveChangesAsync();
            return Ok(new { message = "Cập nhật thành công" });
        }

        [HttpDelete("delete/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound(new { message = "Không tìm thấy người dùng." });

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(new { message = "Xóa thành công" });
        }

        [HttpPost("{userId}/read-notifications")]
        public async Task<IActionResult> ReadNotifications(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound();

            user.LastReadNotificationTime = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            return Ok();
        }
    }

    public class UserCreateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int? ClassId { get; set; }
        public string? SubjectGroup { get; set; }
        public List<int>? SubjectIds { get; set; } = new List<int>();
    }

    public class UserUpdateDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int? ClassId { get; set; }
        public string? SubjectGroup { get; set; }
        public List<int>? SubjectIds { get; set; } = new List<int>();
    }
}
