using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.Models;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ClubController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/club
        [HttpGet]
        public async Task<IActionResult> GetClubs()
        {
            var clubs = await _context.Clubs
                .Include(c => c.President)
                .Include(c => c.Members)
                .ToListAsync();

            var result = clubs.Select(c => new
            {
                c.Id,
                c.Name,
                c.Code,
                c.Type,
                c.Status,
                c.Description,
                PresidentId = c.PresidentId,
                PresidentName = c.President?.FullName,
                MemberCount = c.Members.Count,
                MemberIds = c.Members.Select(m => m.UserId).ToList()
            });

            return Ok(result);
        }

        // GET: api/club/stats
        [HttpGet("stats")]
        public async Task<IActionResult> GetClubStats()
        {
            var totalClubs = await _context.Clubs.CountAsync();
            var totalMembers = await _context.ClubMembers.Select(cm => cm.UserId).Distinct().CountAsync();
            
            // Hardcoded for now based on mockup
            var eventsThisMonth = 18;
            var pendingProposals = 5;

            return Ok(new
            {
                totalClubs,
                totalMembers,
                eventsThisMonth,
                pendingProposals
            });
        }

        // POST: api/club/add
        [HttpPost("add")]
        public async Task<IActionResult> CreateClub([FromBody] ClubCreateDto dto)
        {
            var club = new Club
            {
                Name = dto.Name,
                Type = dto.Type,
                Status = dto.Status,
                Description = dto.Description,
                PresidentId = dto.PresidentId
            };

            // Auto-generate Code: CLB + number (e.g., CLB01)
            var count = await _context.Clubs.CountAsync();
            club.Code = $"CLB{(count + 1).ToString("D2")}";

            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Thêm câu lạc bộ thành công", id = club.Id });
        }

        // PUT: api/club/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateClub(int id, [FromBody] ClubUpdateDto dto)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return NotFound(new { message = "Không tìm thấy câu lạc bộ" });

            club.Name = dto.Name;
            club.Type = dto.Type;
            club.Status = dto.Status;
            club.Description = dto.Description;
            club.PresidentId = dto.PresidentId;

            await _context.SaveChangesAsync();

            return Ok(new { message = "Cập nhật thành công" });
        }

        // DELETE: api/club/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return NotFound(new { message = "Không tìm thấy câu lạc bộ" });

            _context.Clubs.Remove(club);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Xóa thành công" });
        }

        // GET: api/club/{id}/members
        [HttpGet("{id}/members")]
        public async Task<IActionResult> GetClubMembers(int id)
        {
            var members = await _context.ClubMembers
                .Include(cm => cm.User)
                .Where(cm => cm.ClubId == id)
                .Select(cm => new {
                    cm.UserId,
                    Name = cm.User.FullName,
                    Email = cm.User.Email,
                    cm.JoinedDate
                })
                .ToListAsync();

            return Ok(members);
        }

        // POST: api/club/{id}/add-member
        [HttpPost("{id}/add-member")]
        public async Task<IActionResult> AddMember(int id, [FromBody] AddMemberDto dto)
        {
            if (!await _context.Clubs.AnyAsync(c => c.Id == id))
                return NotFound(new { message = "Không tìm thấy câu lạc bộ" });

            if (!await _context.Users.AnyAsync(u => u.Id == dto.UserId))
                return NotFound(new { message = "Không tìm thấy người dùng" });

            if (await _context.ClubMembers.AnyAsync(cm => cm.ClubId == id && cm.UserId == dto.UserId))
                return BadRequest(new { message = "Người dùng đã là thành viên của câu lạc bộ này" });

            var member = new ClubMember
            {
                ClubId = id,
                UserId = dto.UserId,
                JoinedDate = DateTime.UtcNow
            };

            _context.ClubMembers.Add(member);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Thêm thành viên thành công" });
        }

        // DELETE: api/club/{id}/remove-member/{userId}
        [HttpDelete("{id}/remove-member/{userId}")]
        public async Task<IActionResult> RemoveMember(int id, int userId)
        {
            var member = await _context.ClubMembers
                .Include(cm => cm.Club)
                .FirstOrDefaultAsync(cm => cm.ClubId == id && cm.UserId == userId);

            if (member == null)
                return NotFound(new { message = "Thành viên không tồn tại trong câu lạc bộ" });

            var clubName = member.Club?.Name ?? "Câu lạc bộ";

            _context.ClubMembers.Remove(member);
            
            _context.Notifications.Add(new Notification
            {
                UserId = userId,
                Title = "Thông báo từ CLB",
                Message = $"Bạn đã bị xóa khỏi {clubName}.",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();

            return Ok(new { message = "Xóa thành viên thành công" });
        }

        // POST: api/club/{id}/join-request
        [HttpPost("{id}/join-request")]
        public async Task<IActionResult> JoinRequest(int id, [FromBody] JoinRequestDto dto)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return NotFound(new { message = "Không tìm thấy câu lạc bộ" });

            if (club.PresidentId == null) 
                return BadRequest(new { message = "Câu lạc bộ chưa có chủ nhiệm để duyệt đơn" });

            var existingRequest = await _context.AppRequests
                .FirstOrDefaultAsync(r => r.Category == "CLB_JOIN" && r.ReferenceId == id && r.SenderId == dto.UserId && r.Status == "Chờ duyệt");
            
            if (existingRequest != null)
                return BadRequest(new { message = "Bạn đã gửi yêu cầu và đang chờ duyệt" });

            var user = await _context.Users.FindAsync(dto.UserId);
            var senderName = user != null ? user.FullName : "Một học sinh";

            var request = new AppRequest
            {
                Title = $"Yêu cầu tham gia {club.Name}",
                Content = string.IsNullOrEmpty(dto.Reason) ? "Xin chào, tôi muốn tham gia câu lạc bộ này." : dto.Reason,
                Category = "CLB_JOIN",
                Status = "Chờ duyệt",
                SenderId = dto.UserId,
                ReceiverIds = club.PresidentId.Value.ToString(),
                ReferenceId = id,
                CreatedDate = DateTime.UtcNow
            };

            _context.AppRequests.Add(request);

            _context.Notifications.Add(new Notification
            {
                UserId = club.PresidentId.Value,
                Title = "Yêu cầu tham gia CLB mới",
                Message = $"{senderName} muốn tham gia {club.Name}.",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();

            return Ok(new { message = "Gửi yêu cầu thành công" });
        }

        // GET: api/club/{id}/pending-requests
        [HttpGet("{id}/pending-requests")]
        public async Task<IActionResult> GetPendingRequests(int id)
        {
            var requests = await _context.AppRequests
                .Include(r => r.Sender)
                .Where(r => r.Category == "CLB_JOIN" && r.ReferenceId == id && r.Status == "Chờ duyệt")
                .Select(r => new
                {
                    r.Id,
                    r.Title,
                    r.Content,
                    r.SenderId,
                    SenderName = r.Sender != null ? r.Sender.FullName : "Unknown",
                    SenderCode = r.Sender != null ? r.Sender.StudentId : "Unknown",
                    Date = r.CreatedDate.ToString("dd/MM/yyyy HH:mm")
                })
                .ToListAsync();

            return Ok(requests);
        }

        // POST: api/club/{id}/transfer-president
        [HttpPost("{id}/transfer-president")]
        public async Task<IActionResult> TransferPresident(int id, [FromBody] TransferPresidentDto dto)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null) return NotFound(new { message = "Không tìm thấy câu lạc bộ" });

            if (club.PresidentId != dto.CurrentPresidentId)
                return BadRequest(new { message = "Bạn không có quyền chuyển chức chủ nhiệm" });

            var newPresident = await _context.Users.FindAsync(dto.NewPresidentId);
            if (newPresident == null)
                return NotFound(new { message = "Không tìm thấy người dùng được chỉ định" });

            club.PresidentId = dto.NewPresidentId;

            // Ensure new president is in members
            if (!await _context.ClubMembers.AnyAsync(cm => cm.ClubId == id && cm.UserId == dto.NewPresidentId))
            {
                _context.ClubMembers.Add(new ClubMember
                {
                    ClubId = id,
                    UserId = dto.NewPresidentId,
                    JoinedDate = DateTime.UtcNow
                });
            }

            _context.Notifications.Add(new Notification
            {
                UserId = dto.NewPresidentId,
                Title = "Chuyển giao quyền Chủ nhiệm",
                Message = $"Bạn đã được bổ nhiệm làm Chủ nhiệm {club.Name}.",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return Ok(new { message = "Chuyển quyền thành công" });
        }
    }

    public class ClubCreateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = "HOẠT ĐỘNG";
        public string Description { get; set; } = string.Empty;
        public int? PresidentId { get; set; }
    }

    public class ClubUpdateDto
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? PresidentId { get; set; }
    }

    public class AddMemberDto
    {
        public int UserId { get; set; }
    }

    public class JoinRequestDto
    {
        public int UserId { get; set; }
        public string Reason { get; set; } = string.Empty;
    }

    public class TransferPresidentDto
    {
        public int CurrentPresidentId { get; set; }
        public int NewPresidentId { get; set; }
    }
}
