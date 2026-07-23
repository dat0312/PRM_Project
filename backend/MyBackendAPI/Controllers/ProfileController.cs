using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.DTOs;
using System.Security.Claims;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProfileController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProfileController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("me")]
        public async Task<IActionResult> GetMyProfile()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            var user = await _context.Users
                .Include(u => u.Class)
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.Id == int.Parse(userIdClaim));

            if (user == null) return NotFound(new { message = "Không tìm thấy người dùng." });

            string computedClassName = user.Class?.Name ?? "";
            if (user.Class != null && user.Class.StartYear > 0)
            {
                int currentYear = DateTime.Now.Year;
                if (DateTime.Now.Month < 8) currentYear--;
                int yearDiff = currentYear - user.Class.StartYear;
                int computedGrade = 10 + yearDiff;
                
                if (computedGrade > 12) computedClassName = $"Cựu học sinh {user.Class.Name}";
                else computedClassName = $"{computedGrade}{user.Class.Name}";
                
                if (!string.IsNullOrEmpty(user.Class.Cohort)) computedClassName += $" - {user.Class.Cohort}";
            }

            return Ok(new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.PhoneNumber,
                user.StudentId,
                ClassName = computedClassName,
                user.AvatarUrl,
                user.DateOfBirth,
                Roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList()
            });
        }

        [HttpPut("me")]
        public async Task<IActionResult> UpdateMyProfile([FromBody] UpdateProfileDto dto)
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == int.Parse(userIdClaim));
            if (user == null) return NotFound(new { message = "Không tìm thấy người dùng." });

            // Cập nhật thông tin (Khóa hoàn toàn StudentId và ClassName)
            if (!string.IsNullOrEmpty(dto.Email))
            {
                if (await _context.Users.AnyAsync(u => u.Email == dto.Email && u.Id != user.Id))
                {
                    return BadRequest(new { message = "Email này đã được sử dụng." });
                }
                user.Email = dto.Email;
            }

            if (!string.IsNullOrEmpty(dto.PhoneNumber))
            {
                if (await _context.Users.AnyAsync(u => u.PhoneNumber == dto.PhoneNumber && u.Id != user.Id))
                {
                    return BadRequest(new { message = "Số điện thoại này đã được sử dụng." });
                }
                user.PhoneNumber = dto.PhoneNumber;
            }

            if (dto.AvatarUrl != null) user.AvatarUrl = dto.AvatarUrl;
            if (dto.DateOfBirth.HasValue) user.DateOfBirth = dto.DateOfBirth.Value;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật hồ sơ thành công.", user });
        }
    }
}
