using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Web_App.Controllers
{
    [Route("api/web/schedule")]
    [ApiController]
    public class ScheduleBffController : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public ScheduleBffController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("BackendApi");
            _configuration = configuration;
        }

        private void ForwardAuthHeader()
        {
            var token = User.FindFirst("Token")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSchedules([FromQuery] DateTime? startDate, [FromQuery] DateTime? endDate, [FromQuery] int? classId)
        {
            ForwardAuthHeader();
            var url = $"/api/schedule?startDate={startDate:O}&endDate={endDate:O}&classId={classId}";
            var response = await _httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpGet("rooms")]
        public async Task<IActionResult> GetRooms()
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync("/api/room");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("substitutes")]
        public async Task<IActionResult> GetSubstitutes([FromQuery] int scheduleId)
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync($"/api/schedule/substitutes/{scheduleId}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> CreateBulkSchedules([FromBody] object payload)
        {
            ForwardAuthHeader();
            var response = await _httpClient.PostAsJsonAsync("/api/schedule/bulk", payload);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, content);
            return Content(content, "application/json");
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> UpdateSchedule(int id, [FromBody] object payload)
        {
            ForwardAuthHeader();
            var response = await _httpClient.PutAsJsonAsync($"/api/schedule/{id}", payload);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, content);
            return Content(content, "application/json");
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSchedule(int id)
        {
            ForwardAuthHeader();
            var response = await _httpClient.DeleteAsync($"/api/schedule/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, content);
            return Content(content, "application/json");
        }

        [HttpDelete("class/{classId}")]
        public async Task<IActionResult> DeleteAllClassSchedules(int classId)
        {
            ForwardAuthHeader();
            var response = await _httpClient.DeleteAsync($"/api/schedule/class/{classId}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, content);
            return Content(content, "application/json");
        }

        [HttpGet("requests")]
        public async Task<IActionResult> GetRequests()
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync("/api/schedule/requests");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScheduleById(int id)
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync($"/api/schedule/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("request/{id}")]
        public async Task<IActionResult> GetRequestById(int id)
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync($"/api/schedule/request/{id}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPut("request/{id}/status")]
        public async Task<IActionResult> UpdateRequestStatus(int id, [FromBody] object payload)
        {
            ForwardAuthHeader();
            var response = await _httpClient.PutAsJsonAsync($"/api/schedule/requests/{id}/status", payload);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
                return StatusCode((int)response.StatusCode, content);
            return Content(content, "application/json");
        }

        [HttpGet("class/{classId}/occupied-patterns")]
        public async Task<IActionResult> GetOccupiedPatterns(int classId)
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync($"/api/schedule/class/{classId}/occupied-patterns");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync("/api/subject");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
        
        [HttpGet("teachers")]
        public async Task<IActionResult> GetTeachers()
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync("/api/user/teachers");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("subject/{subjectId}/teachers")]
        public async Task<IActionResult> GetTeachersBySubject(int subjectId)
        {
            ForwardAuthHeader();
            var response = await _httpClient.GetAsync($"/api/subject/{subjectId}/teachers");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }
    }
}
