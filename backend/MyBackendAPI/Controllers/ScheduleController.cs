using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBackendAPI.Data;
using MyBackendAPI.DTOs;
using MyBackendAPI.Models;

using Microsoft.AspNetCore.SignalR;
using MyBackendAPI.Hubs;

namespace MyBackendAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ScheduleController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<NotificationHub> _hubContext;

        public ScheduleController(AppDbContext context, IHubContext<NotificationHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        private string GetSlotName(int slot)
        {
            return $"Slot {slot}";
        }

        private string GetStartTime(int slot)
        {
            return slot switch {
                1 => "07:30",
                2 => "10:00",
                3 => "12:50",
                4 => "15:20",
                5 => "17:50",
                6 => "20:20",
                _ => "00:00"
            };
        }

        private string GetEndTime(int slot)
        {
            return slot switch {
                1 => "09:50",
                2 => "12:20",
                3 => "15:10",
                4 => "17:40",
                5 => "20:10",
                6 => "22:40",
                _ => "00:00"
            };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScheduleDto>> GetScheduleById(int id)
        {
            var schedule = await _context.Schedules
                .Include(s => s.Teacher)
                .Include(s => s.Class)
                .Include(s => s.Room)
                .FirstOrDefaultAsync(s => s.Id == id);
            
            if (schedule == null) return NotFound();
            
            return Ok(new ScheduleDto
            {
                Id = schedule.Id,
                DateLabel = schedule.Date.ToString("dd/MM/yyyy"),
                Slot = GetSlotName(schedule.Slot),
                StartTime = GetStartTime(schedule.Slot),
                EndTime = GetEndTime(schedule.Slot),
                Room = schedule.Room?.Name ?? "",
                SubjectCode = schedule.SubjectCode,
                SubjectName = schedule.SubjectCode, // Assuming we don't eager load subject here
                SessionNo = 1,
                ClassName = schedule.Class?.Name ?? "",
                ClassSize = schedule.ClassSize,
                Lecturer = schedule.Teacher?.FullName ?? "",
                Status = schedule.Status,
                RoomId = schedule.RoomId,
                TeacherId = schedule.TeacherId,
                ClassId = schedule.ClassId,
                Date = schedule.Date,
                RawSlot = schedule.Slot
            });
        }

        // GET: api/schedule
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetSchedules([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] int? roomId, [FromQuery] int? teacherId, [FromQuery] int? classId)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
            {
                return Unauthorized("Invalid user token");
            }

            var user = await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null)
                return NotFound("User not found");

            if (user.UserRoles.Any(ur => ur.Role.RoleName == "Parent") && user.ChildId.HasValue)
            {
                user = await _context.Users
                    .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Role)
                    .FirstOrDefaultAsync(u => u.Id == user.ChildId.Value);
                if (user == null) return NotFound("Child user not found");
            }

            var roles = user.UserRoles.Select(ur => ur.Role.RoleName).ToList();

            var query = _context.Schedules.Include(s => s.Teacher).Include(s => s.Class).Include(s => s.Room).AsQueryable();

            if (startDate.HasValue)
                query = query.Where(s => s.Date >= startDate.Value);
            
            if (endDate.HasValue)
                query = query.Where(s => s.Date <= endDate.Value);

            if (roles.Contains("Admin"))
            {
                if (roomId.HasValue) query = query.Where(s => s.RoomId == roomId.Value);
                if (teacherId.HasValue) query = query.Where(s => s.TeacherId == teacherId.Value);
                if (classId.HasValue) query = query.Where(s => s.ClassId == classId.Value);
            }
            else if (roles.Contains("Teacher"))
            {
                if (classId.HasValue)
                {
                    var isHomeroom = await _context.Classes.AnyAsync(c => c.Id == classId.Value && c.HomeroomTeacherId == userId);
                    if (isHomeroom)
                    {
                        query = query.Where(s => s.ClassId == classId.Value);
                    }
                    else
                    {
                        query = query.Where(s => s.TeacherId == userId && s.ClassId == classId.Value);
                    }
                }
                else
                {
                    query = query.Where(s => s.TeacherId == userId);
                }
            }
            else
            {
                if (!user.ClassId.HasValue)
                {
                    return Ok(new List<ScheduleDto>());
                }
                query = query.Where(s => s.ClassId == user.ClassId.Value);
            }

            var schedules = await query.OrderBy(s => s.Date).ThenBy(s => s.Slot).ToListAsync();

            var subjectCodes = schedules.Select(s => s.SubjectCode).Distinct().ToList();
            var subjects = await _context.Subjects.Where(s => subjectCodes.Contains(s.Code)).ToDictionaryAsync(s => s.Code, s => s.Name);

            var dtos = schedules.Select(s => {
                string computedClassName = s.Class?.Name ?? "Unknown";
                if (s.Class != null && s.Class.StartYear > 0)
                {
                    // Academic year start is August 1st.
                    int scheduleYear = s.Date.Year;
                    if (s.Date.Month < 8) scheduleYear--; // If before Aug, it belongs to previous year

                    int yearDiff = scheduleYear - s.Class.StartYear;
                    int computedGrade = 10 + yearDiff;
                    computedClassName = $"{computedGrade}{s.Class.Name}";
                    if (!string.IsNullOrEmpty(s.Class.Cohort)) computedClassName += $" - {s.Class.Cohort}";
                }
                
                return new ScheduleDto
                {
                    Id = s.Id,
                    DateLabel = s.Date.ToString("d/M ddd", CultureInfo.InvariantCulture),
                    Slot = GetSlotName(s.Slot),
                    StartTime = GetStartTime(s.Slot),
                    EndTime = GetEndTime(s.Slot),
                    Room = s.Room?.Name ?? "Unknown",
                    SubjectCode = s.SubjectCode,
                    SubjectName = subjects.ContainsKey(s.SubjectCode) ? subjects[s.SubjectCode] : s.SubjectCode,
                    SessionNo = 1,
                    ClassName = computedClassName,
                    ClassSize = s.ClassSize,
                    Lecturer = s.Teacher != null ? s.Teacher.FullName : "Unknown",
                    Status = s.Status,
                    RoomId = s.RoomId,
                    TeacherId = s.TeacherId,
                    ClassId = s.ClassId,
                    Date = s.Date,
                    RawSlot = s.Slot
                };
            }).ToList();

            return Ok(dtos);
        }

        // GET: api/schedule/occupied-slots
        [HttpGet("occupied-slots")]
        [Authorize(Roles = "Teacher,Admin")]
        public async Task<ActionResult<IEnumerable<int>>> GetOccupiedSlots([FromQuery] DateTime date, [FromQuery] int classId)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
            {
                return Unauthorized();
            }

            var classSlots = await _context.Schedules
                .Where(s => s.Date.Date == date.Date && s.ClassId == classId)
                .Select(s => s.Slot)
                .ToListAsync();

            var teacherSlots = await _context.Schedules
                .Where(s => s.Date.Date == date.Date && s.TeacherId == userId)
                .Select(s => s.Slot)
                .ToListAsync();

            var occupied = classSlots.Concat(teacherSlots).Distinct().ToList();
            return Ok(occupied);
        }

        // GET: api/schedule/class/{classId}/occupied-patterns
        [HttpGet("class/{classId}/occupied-patterns")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<object>>> GetOccupiedPatterns(int classId)
        {
            var patterns = await _context.Schedules
                .Where(s => s.ClassId == classId && s.Date >= DateTime.Today)
                .Select(s => new {
                    // Entity Framework can extract DayOfWeek in queries for SQL Server.
                    dayOfWeek = (int)s.Date.DayOfWeek,
                    slot = s.Slot
                })
                .Distinct()
                .ToListAsync();

            return Ok(patterns);
        }

        // POST: api/schedule
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateSchedule([FromBody] Schedule schedule)
        {
            var conflictMsg = await GetConflictMessageAsync(schedule);
            if (conflictMsg != null)
            {
                return BadRequest(new { message = conflictMsg });
            }

            _context.Schedules.Add(schedule);
            await _context.SaveChangesAsync();
            return Ok(schedule);
        }

        // POST: api/schedule/bulk
        [HttpPost("bulk")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateBulkSchedules([FromBody] BulkScheduleRequestDto request)
        {
            var schedulesToCreate = new List<Schedule>();
            var currentDate = request.StartDate;
            int sessionsCreated = 0;
            int maxDaysToSearch = request.TotalSessions * 7; 
            int daysSearched = 0;

            while (sessionsCreated < request.TotalSessions && daysSearched < maxDaysToSearch)
            {
                int dayOfWeek = (int)currentDate.DayOfWeek;
                // C# DayOfWeek: 0 = Sunday, 1 = Monday, ..., 6 = Saturday
                var matchingSlots = request.DaySlots.Where(d => d.DayOfWeek == dayOfWeek).ToList();
                
                foreach (var daySlot in matchingSlots)
                {
                    if (sessionsCreated >= request.TotalSessions) break;

                    var newSchedule = new Schedule
                    {
                        Date = currentDate.Date,
                        Slot = daySlot.Slot,
                        RoomId = daySlot.RoomId,
                        SubjectCode = request.SubjectCode,
                        ClassId = request.ClassId,
                        ClassSize = 30,
                        TeacherId = request.TeacherId,
                        Status = "FUTURE"
                    };

                    var conflictMsg = await GetConflictMessageAsync(newSchedule);
                    if (conflictMsg != null)
                    {
                        return BadRequest(new { message = $"Tạo lịch thất bại. Lỗi tại ngày {currentDate:dd/MM/yyyy} (Slot {daySlot.Slot}): {conflictMsg}" });
                    }

                    schedulesToCreate.Add(newSchedule);
                    sessionsCreated++;
                }
                currentDate = currentDate.AddDays(1);
                daysSearched++;
            }

            if (schedulesToCreate.Any())
            {
                _context.Schedules.AddRange(schedulesToCreate);
                await _context.SaveChangesAsync();
            }

            return Ok(new { message = $"Đã tạo thành công {sessionsCreated} buổi học." });
        }

        // PUT: api/schedule/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] Schedule schedule)
        {
            if (id != schedule.Id)
            {
                return BadRequest(new { message = "ID không khớp." });
            }

            var conflictMsg = await GetConflictMessageAsync(schedule, id);
            if (conflictMsg != null)
            {
                return BadRequest(new { message = conflictMsg });
            }

            _context.Entry(schedule).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/schedule/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            var schedule = await _context.Schedules.FindAsync(id);
            if (schedule == null)
            {
                return NotFound(new { message = "Không tìm thấy buổi học." });
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/schedule/class/5
        [HttpDelete("class/{classId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAllClassSchedules(int classId)
        {
            var classExists = await _context.Classes.AnyAsync(c => c.Id == classId);
            if (!classExists)
            {
                return NotFound(new { message = "Không tìm thấy lớp học." });
            }

            var schedules = await _context.Schedules.Where(s => s.ClassId == classId).ToListAsync();
            if (schedules.Any())
            {
                _context.Schedules.RemoveRange(schedules);
                await _context.SaveChangesAsync();
            }

            return NoContent();
        }

        private async Task<string?> GetConflictMessageAsync(Schedule schedule, int? ignoreId = null)
        {
            var query = _context.Schedules.Include(s => s.Teacher).Include(s => s.Room).AsQueryable();
            if (ignoreId.HasValue) query = query.Where(s => s.Id != ignoreId.Value);

            var conflicts = await query.Where(s => s.Date == schedule.Date && s.Slot == schedule.Slot).ToListAsync();
            foreach (var existing in conflicts)
            {
                if (existing.ClassId == schedule.ClassId)
                {
                    return $"Lớp này đã có lịch học môn {existing.SubjectCode} vào Ca {schedule.Slot} ngày {schedule.Date:dd/MM/yyyy}.";
                }
                if (existing.RoomId == schedule.RoomId) 
                {
                    return $"Phòng {existing.Room?.Name} đã có lớp khác sử dụng vào Ca {schedule.Slot} ngày {schedule.Date:dd/MM/yyyy}.";
                }
                if (existing.TeacherId == schedule.TeacherId) 
                {
                    return $"Giáo viên {existing.Teacher?.FullName} đã bị trùng lịch vào Ca {schedule.Slot} ngày {schedule.Date:dd/MM/yyyy}.";
                }
            }
            return null;
        }

        // GET: api/schedule/requests
        [HttpGet("requests")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ScheduleRequest>>> GetRequests()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(u => u.Id.ToString() == userIdString);
            if (user == null) return Unauthorized();

            var query = _context.ScheduleRequests
                .Include(sr => sr.Teacher)
                .Include(sr => sr.Schedule)
                    .ThenInclude(s => s.Class)
                .Include(sr => sr.Schedule)
                    .ThenInclude(s => s.Room)
                .AsQueryable();

            var isAdmin = user.UserRoles.Any(ur => ur.Role.RoleName == "Admin");
            if (!isAdmin && user.UserRoles.Any(ur => ur.Role.RoleName == "Teacher"))
            {
                query = query.Where(sr => sr.TeacherId == user.Id);
            }

            var requests = await query.OrderByDescending(sr => sr.CreatedAt).ToListAsync();
            foreach(var r in requests) {
                if (r.Teacher != null) r.Teacher.UserRoles = null;
                if (r.Schedule != null) r.Schedule.Teacher = null;
            }
            return Ok(requests);
        }

        // POST: api/schedule/requests
        [HttpPost("requests")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> CreateRequest([FromBody] ScheduleRequest request)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out int userId))
            {
                return Unauthorized();
            }

            request.TeacherId = userId;
            request.CreatedAt = DateTime.UtcNow;
            request.Status = "Pending";
            _context.ScheduleRequests.Add(request);
            await _context.SaveChangesAsync();

            var admins = await _context.UserRoles.Include(ur => ur.Role).Where(ur => ur.Role.RoleName == "Admin").Select(ur => ur.UserId).ToListAsync();
            var notifs = admins.Select(adminId => new Notification {
                UserId = adminId,
                Title = "Yêu cầu mới",
                Message = $"Giảng viên vừa gửi một yêu cầu {request.RequestType}.",
                RelatedRequestId = request.Id
            }).ToList();
            _context.Notifications.AddRange(notifs);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.Group("Admins").SendAsync("ReceiveNotification", "Có yêu cầu lịch mới từ Giảng viên.");

            return Ok(request);
        }

        // GET: api/schedule/substitutes/{scheduleId}
        [HttpGet("substitutes/{scheduleId}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<User>>> GetAvailableSubstituteTeachers(int scheduleId)
        {
            var schedule = await _context.Schedules.FindAsync(scheduleId);
            if (schedule == null) return NotFound();

            var subject = await _context.Subjects.FirstOrDefaultAsync(s => s.Code == schedule.SubjectCode);
            if (subject == null) return BadRequest("Không tìm thấy môn học");

            // Find teachers who teach this subject
            var teacherIds = await _context.TeacherSubjects
                .Where(ts => ts.SubjectId == subject.Id)
                .Select(ts => ts.TeacherId)
                .ToListAsync();

            // Find teachers who are already busy on that date and slot
            var busyTeacherIds = await _context.Schedules
                .Where(s => s.Date.Date == schedule.Date.Date && s.Slot == schedule.Slot)
                .Select(s => s.TeacherId)
                .ToListAsync();

            var availableTeacherIds = teacherIds.Except(busyTeacherIds).ToList();

            var availableTeachers = await _context.Users
                .Where(u => availableTeacherIds.Contains(u.Id))
                .Select(u => new { u.Id, u.FullName, u.PhoneNumber })
                .ToListAsync();

            return Ok(availableTeachers);
        }

        // GET: api/schedule/request/{id}
        [HttpGet("request/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<ScheduleRequest>> GetRequestById(int id)
        {
            var req = await _context.ScheduleRequests
                .Include(sr => sr.Schedule)
                .FirstOrDefaultAsync(r => r.Id == id);
            
            if (req == null) return NotFound();
            if (req.Schedule != null) {
                req.Schedule.Class = null;
                req.Schedule.Room = null;
                req.Schedule.Teacher = null;
            }
            return Ok(req);
        }

        public class UpdateStatusDto { 
            public string Status { get; set; } = string.Empty; 
            public int? SubstituteTeacherId { get; set; }
        }

        // PUT: api/schedule/requests/{id}/status
        [HttpPut("requests/{id}/status")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRequestStatus(int id, [FromBody] UpdateStatusDto dto)
        {
            var req = await _context.ScheduleRequests.Include(r => r.Schedule).FirstOrDefaultAsync(r => r.Id == id);
            if (req == null) return NotFound();

            req.Status = dto.Status;

            if (dto.Status == "Approved")
            {
                if (req.RequestType == "Leave" && dto.SubstituteTeacherId.HasValue && req.Schedule != null)
                {
                    req.Schedule.TeacherId = dto.SubstituteTeacherId.Value;
                    
                    _context.Notifications.Add(new Notification { UserId = req.TeacherId, Title = "Đơn xin nghỉ được duyệt", Message = $"Đơn xin nghỉ ngày {req.Schedule.Date:dd/MM/yyyy} ca {req.Schedule.Slot} đã được duyệt.", RelatedRequestId = req.Id });
                    _context.Notifications.Add(new Notification { UserId = dto.SubstituteTeacherId.Value, Title = "Lịch dạy thay mới", Message = $"Bạn được xếp dạy thay môn {req.Schedule.SubjectCode} vào ngày {req.Schedule.Date:dd/MM/yyyy} ca {req.Schedule.Slot}.", RelatedRequestId = req.Id });
                    
                    await _hubContext.Clients.Group($"User_{req.TeacherId}").SendAsync("ReceiveNotification", "Đơn xin nghỉ được duyệt");
                    await _hubContext.Clients.Group($"User_{dto.SubstituteTeacherId.Value}").SendAsync("ReceiveNotification", "Lịch dạy thay mới");
                }
                else if (req.RequestType == "Makeup" && req.MakeUpDate.HasValue && req.MakeUpSlot.HasValue && req.Schedule != null)
                {
                    req.Schedule.Date = req.MakeUpDate.Value;
                    req.Schedule.Slot = req.MakeUpSlot.Value;

                    _context.Notifications.Add(new Notification { UserId = req.TeacherId, Title = "Đơn dạy bù được duyệt", Message = $"Đơn dạy bù môn {req.Schedule.SubjectCode} đã được dời sang ngày {req.MakeUpDate.Value:dd/MM/yyyy} ca {req.MakeUpSlot.Value}.", RelatedRequestId = req.Id });
                    await _hubContext.Clients.Group($"User_{req.TeacherId}").SendAsync("ReceiveNotification", "Đơn dạy bù được duyệt");
                }
            }
            else if (dto.Status == "Rejected")
            {
                _context.Notifications.Add(new Notification { UserId = req.TeacherId, Title = "Đơn bị từ chối", Message = $"Đơn {req.RequestType} của bạn đã bị từ chối.", RelatedRequestId = req.Id });
                await _hubContext.Clients.Group($"User_{req.TeacherId}").SendAsync("ReceiveNotification", "Đơn bị từ chối");
            }

            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
