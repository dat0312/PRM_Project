using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Net.Http;

using Microsoft.AspNetCore.Authorization;

namespace Web_App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/web/request")]
    public class AppRequestBffController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AppRequestBffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        private HttpClient GetClient()
        {
            var client = _httpClientFactory.CreateClient("BackendApi");
            var token = User.FindFirst("Token")?.Value;
            if (!string.IsNullOrEmpty(token))
            {
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            return client;
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserRequests(int userId)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/AppRequest/user/{userId}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPost("{id}/approve")]
        public async Task<IActionResult> ApproveRequest(int id, [FromQuery] int? substituteTeacherId)
        {
            var client = GetClient();
            string url = $"/api/AppRequest/{id}/approve";
            if (substituteTeacherId.HasValue)
            {
                url += $"?substituteTeacherId={substituteTeacherId.Value}";
            }
            var response = await client.PostAsync(url, null);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost("{id}/reject")]
        public async Task<IActionResult> RejectRequest(int id)
        {
            var client = GetClient();
            var response = await client.PostAsync($"/api/AppRequest/{id}/reject", null);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpDelete("{id}/hide")]
        public async Task<IActionResult> HideRequest(int id, [FromQuery] int userId)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"/api/AppRequest/{id}/hide?userId={userId}");
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpPost("compose")]
        public async Task<IActionResult> ComposeRequest([FromBody] JsonElement payload)
        {
            var client = GetClient();
            var body = new StringContent(payload.GetRawText(), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/AppRequest/compose", body);
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }

        [HttpGet("schedule/substitutes/{scheduleId}")]
        public async Task<IActionResult> GetSubstitutes(int scheduleId)
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/schedule/substitutes/{scheduleId}");
            var content = await response.Content.ReadAsStringAsync();
            return StatusCode((int)response.StatusCode, content);
        }
    }
}
