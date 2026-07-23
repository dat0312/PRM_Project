using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Web_App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/web/grades")]
    public class GradeBffController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public GradeBffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("BackendApi");
            var token = User.FindFirst("Token")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllGrades()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/grades/all");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("class/{classId}")]
        public async Task<IActionResult> GetClassGrades(int classId)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/grades/class/{classId}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Content(content, "application/json");
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpGet("class/{classId}/my-subjects")]
        public async Task<IActionResult> GetMySubjectsForClass(int classId)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/grades/class/{classId}/my-subjects");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Content(content, "application/json");
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost]
        public async Task<IActionResult> AddOrUpdateGrade([FromBody] JsonElement payload)
        {
            var client = GetClient();
            var body = new StringContent(payload.GetRawText(), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/grades", body);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Content(content, "application/json");
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpDelete("student/{id}")]
        public async Task<IActionResult> DeleteStudentGrades(int id)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"/api/grades/student/{id}");
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Content(content, "application/json");
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPut("class/{classId}/lock")]
        public async Task<IActionResult> ToggleLockGrade(int classId, [FromBody] bool isLocked)
        {
            var client = GetClient();
            var body = new StringContent(JsonSerializer.Serialize(isLocked), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/grades/class/{classId}/lock", body);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Content(content, "application/json");
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPut("student/{studentId}")]
        public async Task<IActionResult> UpdateStudentGrades(int studentId, [FromBody] JsonElement payload)
        {
            var client = GetClient();
            var grades = JsonSerializer.Deserialize<List<object>>(payload.GetRawText());
            bool hasError = false;
            foreach (var gradeData in grades)
            {
                var body = new StringContent(JsonSerializer.Serialize(gradeData), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("/api/grades", body);
                if (!response.IsSuccessStatusCode) hasError = true;
            }
            if (hasError) return BadRequest("Có lỗi khi lưu một số cột điểm");
            return Ok();
        }

        [HttpPut("lock-all")]
        public async Task<IActionResult> ToggleLockAllGrades([FromBody] bool isLocked)
        {
            var client = GetClient();
            var body = new StringContent(JsonSerializer.Serialize(isLocked), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/grades/lock-all", body);
            var content = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Content(content, "application/json");
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpGet("academic-years")]
        public async Task<IActionResult> GetAcademicYears()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/class/academic-years");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("export/{classId}")]
        public async Task<IActionResult> ExportExcel(int classId, [FromQuery] int subjectId, [FromQuery] string academicYear = "2025-2026", [FromQuery] int? studentId = null)
        {
            var client = GetClient();
            var url = $"/api/grades/export/{classId}?subjectId={subjectId}&academicYear={academicYear}";
            if (studentId.HasValue) url += $"&studentId={studentId.Value}";

            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var fileBytes = await response.Content.ReadAsByteArrayAsync();
                var contentType = response.Content.Headers.ContentType?.ToString() ?? "application/octet-stream";
                var fileName = response.Content.Headers.ContentDisposition?.FileNameStar ?? $"Diem_{classId}_{subjectId}.xlsx";
                return File(fileBytes, contentType, fileName);
            }
            var error = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, error);
        }

        [HttpPost("import/{classId}")]
        public async Task<IActionResult> ImportExcel(int classId, [FromQuery] int subjectId, [FromQuery] string academicYear = "2025-2026", IFormFile file = null)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded");

            var client = GetClient();
            using var content = new MultipartFormDataContent();
            using var stream = file.OpenReadStream();
            content.Add(new StreamContent(stream), "file", file.FileName);

            var response = await client.PostAsync($"/api/grades/import/{classId}?subjectId={subjectId}&academicYear={academicYear}", content);
            var responseStr = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode) return Content(responseStr, "application/json");
            return StatusCode((int)response.StatusCode, responseStr);
        }
    }
}
