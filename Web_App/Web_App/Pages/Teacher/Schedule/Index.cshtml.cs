using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Net.Http.Headers;

namespace Web_App.Pages.Teacher.Schedule
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public DateTime StartOfWeek { get; set; }
        public DateTime EndOfWeek { get; set; }
        public DateTime SelectedDate { get; set; }
        public List<DateTime> WeekDates { get; set; } = new List<DateTime>();

        public List<ScheduleModel> Schedules { get; set; } = new List<ScheduleModel>();
        public List<ScheduleRequestModel> Requests { get; set; } = new List<ScheduleRequestModel>();

        [BindProperty(SupportsGet = true)]
        public DateTime? RequestDate { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            SelectedDate = RequestDate ?? DateTime.Today;
            CalculateWeekDates();

            var token = User.FindFirst("Token")?.Value;
            if (string.IsNullOrEmpty(token)) return RedirectToPage("/Login");

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Fetch schedules
            var startDateStr = StartOfWeek.ToString("yyyy-MM-ddTHH:mm:ss");
            var endDateStr = EndOfWeek.ToString("yyyy-MM-ddTHH:mm:ss");
            var response = await client.GetAsync($"/api/schedule?startDate={startDateStr}&endDate={endDateStr}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                Schedules = JsonSerializer.Deserialize<List<ScheduleModel>>(content, options) ?? new List<ScheduleModel>();
            }

            // Fetch requests
            var reqResponse = await client.GetAsync("/api/schedule/requests");
            if (reqResponse.IsSuccessStatusCode)
            {
                var reqContent = await reqResponse.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var allRequests = JsonSerializer.Deserialize<List<ScheduleRequestModel>>(reqContent, options) ?? new List<ScheduleRequestModel>();
                Requests = allRequests.Where(r => r.Status == "Pending").ToList();
            }

            return Page();
        }

        private void CalculateWeekDates()
        {
            int currentDay = (int)SelectedDate.DayOfWeek;
            int diff = currentDay == 0 ? 6 : currentDay - 1; // 0 = Sunday, we want Monday as first day
            StartOfWeek = SelectedDate.AddDays(-diff).Date;
            EndOfWeek = StartOfWeek.AddDays(6).Date.AddHours(23).AddMinutes(59).AddSeconds(59);

            for (int i = 0; i < 7; i++)
            {
                WeekDates.Add(StartOfWeek.AddDays(i));
            }
        }

        [BindProperty]
        public int RequestScheduleId { get; set; }

        [BindProperty]
        public string RequestReason { get; set; }

        public async Task<IActionResult> OnPostLeaveAsync()
        {
            var token = User.FindFirst("Token")?.Value;
            if (string.IsNullOrEmpty(token)) return RedirectToPage("/Login");

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");

            var metadata = new {
                Type = "LEAVE",
                ScheduleId = RequestScheduleId,
                ClassId = RequestClassId,
                Reason = RequestReason
            };

            var reqBody = new
            {
                Title = $"Đơn xin báo nghỉ",
                Content = JsonSerializer.Serialize(metadata),
                Category = "Lịch học",
                Status = "Chờ duyệt",
                SenderId = userId,
                ReceiverIds = "ADMIN"
            };

            var content = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/AppRequest/compose", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Gửi đơn xin nghỉ thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Lỗi khi gửi đơn: " + await response.Content.ReadAsStringAsync();
            }

            return RedirectToPage(new { RequestDate = RequestDate?.ToString("yyyy-MM-dd") });
        }



        [BindProperty]
        public DateTime MakeUpDate { get; set; }

        [BindProperty]
        public int MakeUpSlot { get; set; }
        
        [BindProperty]
        public int RequestClassId { get; set; }

        public async Task<IActionResult> OnPostMakeupAsync()
        {
            var token = User.FindFirst("Token")?.Value;
            if (string.IsNullOrEmpty(token)) return RedirectToPage("/Login");

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var userId = int.Parse(User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value ?? "0");

            var metadata = new {
                Type = "MAKEUP",
                ScheduleId = RequestScheduleId,
                ClassId = RequestClassId,
                NewDate = MakeUpDate.ToString("yyyy-MM-dd"),
                NewSlot = MakeUpSlot,
                Reason = RequestReason
            };

            var reqBody = new
            {
                Title = $"Đơn xin dạy bù",
                Content = JsonSerializer.Serialize(metadata),
                Category = "Lịch học",
                Status = "Chờ duyệt",
                SenderId = userId,
                ReceiverIds = "ADMIN"
            };

            var content = new StringContent(JsonSerializer.Serialize(reqBody), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/AppRequest/compose", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Gửi đơn xin dạy bù thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Lỗi khi gửi đơn: " + await response.Content.ReadAsStringAsync();
            }

            return RedirectToPage(new { RequestDate = RequestDate?.ToString("yyyy-MM-dd") });
        }

        public async Task<IActionResult> OnGetOccupiedSlotsAsync([FromQuery] string date, [FromQuery] int classId)
        {
            var token = User.FindFirst("Token")?.Value;
            if (string.IsNullOrEmpty(token)) return Unauthorized();

            var client = _httpClientFactory.CreateClient("BackendApi");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            
            var response = await client.GetAsync($"/api/schedule/occupied-slots?date={date}&classId={classId}");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            
            return BadRequest();
        }
    }

    public class ScheduleModel
    {
        public int Id { get; set; }
        public string DateLabel { get; set; }
        public string Slot { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string Room { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string ClassName { get; set; }
        public int ClassId { get; set; }
        public int RawSlot { get; set; }
        public DateTime Date { get; set; }
    }

    public class ScheduleRequestModel
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public string RequestType { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? MakeUpDate { get; set; }
        public int? MakeUpSlot { get; set; }
        public TeacherModel Teacher { get; set; }
    }

    public class TeacherModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
    }
}
