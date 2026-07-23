using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MyBackendAPI.Data;
using MyBackendAPI.DTOs;
using MyBackendAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MyBackendAPI.Services;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IEmailService _emailService;

        public AuthController(AppDbContext context, IConfiguration configuration, IEmailService emailService)
        {
            _context = context;
            _configuration = configuration;
            _emailService = emailService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            if (await _context.Users.AnyAsync(u => u.PhoneNumber == dto.PhoneNumber))
                return BadRequest(new { message = "Số điện thoại đã tồn tại!" });

            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
                return BadRequest(new { message = "Email đã tồn tại!" });

            var user = new User
            {
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
                FullName = dto.FullName,
                Password = dto.Password
            };

            // Mặc định gán Role Student (RoleId = 2) cho User mới
            var studentRole = await _context.Roles.FindAsync(2);
            if (studentRole != null)
            {
                user.UserRoles.Add(new UserRole { RoleId = studentRole.Id });
            }

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User registered successfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            // Tìm người dùng và lấy các quyền liên kết
            var user = await _context.Users
                .Include(u => u.Class)
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.PhoneNumber == dto.PhoneNumber);

            // So sánh dấu bằng (==) thuần túy, loại bỏ hoàn toàn băm mật khẩu
            if (user == null || user.Password != dto.Password)
                return Unauthorized(new { message = "Invalid phone number or password" });

            var roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList();
            var token = GenerateJwtToken(user, roles);

            return Ok(new AuthResponseDto
            {
                Id = user.Id,
                Token = token,
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                FullName = user.FullName,
                StudentId = user.StudentId,
                ClassName = user.Class?.Name,
                AvatarUrl = user.AvatarUrl,
                Roles = roles
            });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            return Ok(new { message = "Logged out successfully" });
        }

        [Authorize]
        [HttpGet("me")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdClaim == null) return Unauthorized();

            var user = await _context.Users
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                .SingleOrDefaultAsync(u => u.Id == int.Parse(userIdClaim));

            if (user == null) return NotFound();

            return Ok(new
            {
                user.Id,
                user.PhoneNumber,
                user.Email,
                user.FullName,
                Roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList()
            });
        }

        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return NotFound(new { message = "Email không tồn tại trong hệ thống." });

            // Generate 6-digit OTP
            var otp = new Random().Next(100000, 999999).ToString();
            
            user.ResetPasswordOtp = otp;
            user.ResetPasswordOtpExpiry = DateTime.UtcNow.AddMinutes(5); // Có hiệu lực 5 phút
            await _context.SaveChangesAsync();

            // Gửi email
            string subject = "Yêu cầu khôi phục mật khẩu";
            string body = $"<p>Xin chào {user.FullName},</p><p>Mã OTP để khôi phục mật khẩu của bạn là: <strong>{otp}</strong></p><p>Mã này có hiệu lực trong vòng 5 phút.</p>";
            
            try
            {
                await _emailService.SendEmailAsync(user.Email, subject, body);
            }
            catch (Exception ex)
            {
                // Xử lý nếu gửi mail lỗi, có thể do chưa cấu hình SMTP
                Console.WriteLine($"Error sending email: {ex.Message}");
                return StatusCode(500, new { message = "Có lỗi xảy ra khi gửi email OTP. Vui lòng thử lại sau.", error = ex.Message });
            }

            return Ok(new { message = "Mã OTP đã được gửi đến email của bạn. Vui lòng kiểm tra hộp thư." });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] VerifyOtpDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return NotFound(new { message = "Email không tồn tại." });

            if (user.ResetPasswordOtp != dto.Otp || user.ResetPasswordOtpExpiry < DateTime.UtcNow)
                return BadRequest(new { message = "Mã OTP không hợp lệ hoặc đã hết hạn." });

            return Ok(new { message = "Mã OTP hợp lệ." });
        }

        [HttpPost("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null)
                return NotFound(new { message = "Email không tồn tại." });

            if (user.ResetPasswordOtp != dto.Otp || user.ResetPasswordOtpExpiry < DateTime.UtcNow)
                return BadRequest(new { message = "Mã OTP không hợp lệ hoặc đã hết hạn." });

            // Cập nhật mật khẩu mới (Lưu ý: mật khẩu đang lưu thô theo yêu cầu trước đó)
            user.Password = dto.NewPassword;
            
            // Hủy OTP sau khi sử dụng thành công
            user.ResetPasswordOtp = null;
            user.ResetPasswordOtpExpiry = null;
            
            await _context.SaveChangesAsync();

            return Ok(new { message = "Đặt lại mật khẩu thành công. Bạn có thể đăng nhập ngay bây giờ." });
        }

        private string GenerateJwtToken(User user, List<string> roles)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings["Key"]!));

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.PhoneNumber),
                new Claim("FullName", user.FullName)
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}