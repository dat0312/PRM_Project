using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.Models;
using System.Linq;
using System.Threading.Tasks;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppRequestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AppRequestController(AppDbContext context)
        {
            _context = context;
        }

        // Get requests by userId
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserRequests(int userId)
        {
            var isAdmin = await _context.UserRoles
                .Include(ur => ur.Role)
                .AnyAsync(ur => ur.UserId == userId && ur.Role.RoleName == "Admin");

            var requests = await _context.AppRequests
                .Include(p => p.Sender)
                .OrderByDescending(p => p.CreatedDate)
                .Select(p => new
                {
                    p.Id,
                    p.Title,
                    p.Content,
                    p.SenderId,
                    SenderName = p.Sender != null ? p.Sender.FullName : "Unknown",
                    SenderEmail = p.Sender != null ? p.Sender.Email : "",
                    Date = p.CreatedDate.ToString("dd/MM/yyyy HH:mm"),
                    p.Status,
                    p.Category,
                    p.ReceiverIds,
                    p.ReferenceId,
                    DeletedByIds = p.DeletedByIds
                })
                .ToListAsync();

            // Filter
            var userStr = userId.ToString();
            var result = requests.Where(p => 
                p.SenderId == userId || 
                p.ReceiverIds == "ALL" || 
                (isAdmin && p.ReceiverIds == "ADMIN") ||
                p.ReceiverIds.Split(',').Contains(userStr)
            ).ToList();

            return Ok(result);
        }

        // Compose a new request
        [HttpPost("compose")]
        public async Task<IActionResult> ComposeRequest([FromBody] AppRequestDto dto)
        {
            var newRequest = new AppRequest
            {
                Title = dto.Title,
                Content = dto.Content,
                Category = dto.Category ?? "Tin nhắn",
                Status = dto.Status ?? "Đã nhận",
                SenderId = dto.SenderId,
                ReceiverIds = dto.ReceiverIds ?? "ALL"
            };

            _context.AppRequests.Add(newRequest);
            await _context.SaveChangesAsync();

            // Notify receivers
            if (newRequest.ReceiverIds != "ALL" && newRequest.ReceiverIds != "ADMIN")
            {
                var receiverIdsStr = newRequest.ReceiverIds.Split(',', StringSplitOptions.RemoveEmptyEntries);
                var receiverIds = new List<int>();
                foreach(var str in receiverIdsStr)
                {
                    if (int.TryParse(str, out int parsedId))
                    {
                        receiverIds.Add(parsedId);
                    }
                }

                var sender = await _context.Users.FindAsync(dto.SenderId);
                var senderName = sender?.FullName ?? "Ai đó";

                foreach (var rId in receiverIds)
                {
                    _context.Notifications.Add(new Notification
                    {
                        UserId = rId,
                        Title = $"Đơn/Tin nhắn mới từ {senderName}",
                        Message = dto.Title,
                        RelatedRequestId = newRequest.Id
                    });
                }
                await _context.SaveChangesAsync();
            }
            else if (newRequest.ReceiverIds == "ADMIN")
            {
                var sender = await _context.Users.FindAsync(dto.SenderId);
                var senderName = sender?.FullName ?? "Ai đó";

                var adminIds = await _context.UserRoles
                    .Include(ur => ur.Role)
                    .Where(ur => ur.Role.RoleName == "Admin")
                    .Select(ur => ur.UserId)
                    .ToListAsync();
                
                foreach (var adminId in adminIds)
                {
                    _context.Notifications.Add(new Notification
                    {
                        UserId = adminId,
                        Title = $"Đơn/Tin nhắn mới từ {senderName}",
                        Message = dto.Title,
                        RelatedRequestId = newRequest.Id
                    });
                }
                await _context.SaveChangesAsync();
            }

            return Ok(new { message = "Gửi đơn thành công." });
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveRequest(int id, [FromQuery] int? substituteTeacherId)
        {
            var request = await _context.AppRequests.FindAsync(id);
            if (request == null) return NotFound(new { message = "Không tìm thấy đơn." });

            request.Status = "Đã duyệt";

            // Parse metadata to auto-update schedule
            try 
            {
                if (request.Content.TrimStart().StartsWith("{"))
                {
                    using (var jsonDoc = System.Text.Json.JsonDocument.Parse(request.Content))
                    {
                        var root = jsonDoc.RootElement;
                        if (root.TryGetProperty("Type", out var typeProp))
                        {
                            string type = typeProp.GetString();
                            if (root.TryGetProperty("ScheduleId", out var scheduleIdProp))
                            {
                                int scheduleId = scheduleIdProp.GetInt32();
                                var schedule = await _context.Schedules.FindAsync(scheduleId);
                                if (schedule != null)
                                {
                                    if (type == "MAKEUP")
                                    {
                                        if (root.TryGetProperty("NewDate", out var newDateProp) && 
                                            root.TryGetProperty("NewSlot", out var newSlotProp))
                                        {
                                            schedule.Date = DateTime.Parse(newDateProp.GetString());
                                            schedule.Slot = newSlotProp.GetInt32();
                                            
                                            // Gửi thông báo cho học sinh trong lớp về việc học bù
                                            var students = await _context.Users.Where(u => u.ClassId == schedule.ClassId).ToListAsync();
                                            foreach (var s in students)
                                            {
                                                _context.Notifications.Add(new Notification
                                                {
                                                    UserId = s.Id,
                                                    Title = "Thông báo Lịch học bù",
                                                    Message = $"Môn {schedule.SubjectCode} đã được xếp học bù vào ngày {schedule.Date:dd/MM/yyyy} Slot {schedule.Slot}.",
                                                    CreatedAt = DateTime.UtcNow,
                                                    RelatedRequestId = request.Id
                                                });
                                            }
                                        }
                                    }
                                    else if (type == "LEAVE")
                                    {
                                        if (substituteTeacherId.HasValue)
                                        {
                                            schedule.TeacherId = substituteTeacherId.Value;
                                            // Gửi thông báo cho học sinh trong lớp về việc giáo viên dạy thay
                                            var students = await _context.Users.Where(u => u.ClassId == schedule.ClassId).ToListAsync();
                                            foreach (var s in students)
                                            {
                                                _context.Notifications.Add(new Notification
                                                {
                                                    UserId = s.Id,
                                                    Title = "Thông báo Giáo viên dạy thay",
                                                    Message = $"Môn {schedule.SubjectCode} ngày {schedule.Date:dd/MM/yyyy} Slot {schedule.Slot} sẽ do giáo viên khác dạy thay.",
                                                    CreatedAt = DateTime.UtcNow,
                                                    RelatedRequestId = request.Id
                                                });
                                            }
                                        }
                                        else 
                                        {
                                            return BadRequest(new { message = "Vui lòng chọn Giáo viên dạy thay trước khi duyệt đơn Nghỉ." });
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } 
            catch (Exception ex)
            {
                // Fallback if parsing fails, just approve it as a text request
                Console.WriteLine("Parse JSON failed: " + ex.Message);
            }

            // Handle CLB_JOIN Category
            if (request.Category == "CLB_JOIN" && request.ReferenceId.HasValue)
            {
                int clubId = request.ReferenceId.Value;
                if (!await _context.ClubMembers.AnyAsync(cm => cm.ClubId == clubId && cm.UserId == request.SenderId))
                {
                    _context.ClubMembers.Add(new ClubMember
                    {
                        ClubId = clubId,
                        UserId = request.SenderId,
                        JoinedDate = DateTime.UtcNow
                    });
                }
                
                var club = await _context.Clubs.FindAsync(clubId);
                var clubName = club != null ? club.Name : "Câu lạc bộ";
                
                _context.Notifications.Add(new Notification
                {
                    UserId = request.SenderId,
                    Title = "Yêu cầu tham gia CLB được duyệt",
                    Message = $"Yêu cầu tham gia {clubName} của bạn đã được chủ nhiệm phê duyệt.",
                    CreatedAt = DateTime.UtcNow,
                    RelatedRequestId = request.Id
                });
            }
            else
            {
                // Thông báo chung cho các loại đơn khác
                _context.Notifications.Add(new Notification
                {
                    UserId = request.SenderId,
                    Title = "Đơn từ đã được duyệt",
                    Message = $"Đơn '{request.Title}' của bạn đã được duyệt thành công.",
                    CreatedAt = DateTime.UtcNow,
                    RelatedRequestId = request.Id
                });
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã duyệt đơn thành công." });
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id)
        {
            var request = await _context.AppRequests.FindAsync(id);
            if (request == null) return NotFound(new { message = "Không tìm thấy đơn." });

            request.Status = "Từ chối";

            if (request.Category == "CLB_JOIN" && request.ReferenceId.HasValue)
            {
                var club = await _context.Clubs.FindAsync(request.ReferenceId.Value);
                var clubName = club != null ? club.Name : "Câu lạc bộ";

                _context.Notifications.Add(new Notification
                {
                    UserId = request.SenderId,
                    Title = "Yêu cầu tham gia CLB bị từ chối",
                    Message = $"Yêu cầu tham gia {clubName} của bạn đã bị từ chối.",
                    CreatedAt = DateTime.UtcNow,
                    RelatedRequestId = request.Id
                });
            }
            else
            {
                _context.Notifications.Add(new Notification
                {
                    UserId = request.SenderId,
                    Title = "Đơn từ đã bị từ chối",
                    Message = $"Đơn '{request.Title}' của bạn đã bị từ chối.",
                    CreatedAt = DateTime.UtcNow,
                    RelatedRequestId = request.Id
                });
            }

            await _context.SaveChangesAsync();

            return Ok(new { message = "Đã từ chối đơn." });
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedRequests()
        {
            if (!_context.AppRequests.Any())
            {
                _context.AppRequests.AddRange(
                    new AppRequest { Title = "Đơn xin thành lập CLB Cờ vua", Content = "Tôi muốn lập CLB Cờ Vua...", Category = "CLB", Status = "Chờ duyệt", SenderId = 5, ReceiverIds = "ADMIN" },
                    new AppRequest { Title = "Xin đổi giờ học bù", Content = "Em xin đổi giờ học bù môn Toán...", Category = "Lịch học", Status = "Chờ duyệt", SenderId = 15, ReceiverIds = "ADMIN" },
                    new AppRequest { Title = "Thông báo họp phụ huynh", Content = "Kính gửi quý thầy cô và các bậc phụ huynh...", Category = "Thông báo", Status = "Đã gửi", SenderId = 1, ReceiverIds = "ALL" }
                );
                await _context.SaveChangesAsync();
                return Ok(new { message = "Đã tạo dữ liệu mẫu." });
            }
            return Ok(new { message = "Dữ liệu mẫu đã tồn tại." });
        }

        [HttpGet("unread-status/{userId}")]
        public async Task<IActionResult> GetUnreadStatus(int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null) return NotFound();

            var lastRead = user.LastReadNotificationTime ?? DateTime.MinValue;

            // Admin receives everything, otherwise check ReceiverIds
            var hasUnread = await _context.AppRequests
                .AnyAsync(r => r.CreatedDate > lastRead && r.SenderId != userId);

            return Ok(new { hasUnread });
        }

        [HttpDelete("{id}/hide")]
        public async Task<IActionResult> HideRequest(int id, [FromQuery] int userId)
        {
            var request = await _context.AppRequests.FindAsync(id);
            if (request == null) return NotFound();

            var deletedIds = request.DeletedByIds?.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList() ?? new List<string>();
            var userIdStr = userId.ToString();
            
            if (!deletedIds.Contains(userIdStr))
            {
                deletedIds.Add(userIdStr);
                request.DeletedByIds = string.Join(",", deletedIds);
                await _context.SaveChangesAsync();
            }
            
            return Ok(new { message = "Đã ẩn đơn thành công" });
        }
    }

    public class AppRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int SenderId { get; set; }
        public string? ReceiverIds { get; set; }
        public string? Status { get; set; }
        public int? ReferenceId { get; set; }
        public string? DeletedByIds { get; set; }
    }
}
