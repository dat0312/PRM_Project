using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Web_App.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/web/user")]
    public class UserBffController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public UserBffController(IHttpClientFactory httpClientFactory)
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

        [HttpGet("users")]
        public async Task<IActionResult> GetUsers()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/user/users");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("search-email")]
        public async Task<IActionResult> SearchEmail([FromQuery] string q)
        {
            if (string.IsNullOrEmpty(q)) return Ok(new List<object>());
            var client = GetClient();
            var response = await client.GetAsync($"/api/User/search-email?q={Uri.EscapeDataString(q)}");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("subjects")]
        public async Task<IActionResult> GetSubjects()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/subject");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpGet("classes")]
        public async Task<IActionResult> GetClasses()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/class");
            var content = await response.Content.ReadAsStringAsync();
            return Content(content, "application/json");
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddUser([FromBody] JsonElement data)
        {
            var client = GetClient();
            var content = new StringContent(data.GetRawText(), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/user/add", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                return Content(responseContent, "application/json");
            }
            
            return StatusCode((int)response.StatusCode, responseContent);
        }

        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditUser(int id, [FromBody] JsonElement data)
        {
            var client = GetClient();
            var content = new StringContent(data.GetRawText(), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"/api/user/edit/{id}", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                return Content(responseContent, "application/json");
            }

            return StatusCode((int)response.StatusCode, responseContent);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var client = GetClient();
            var response = await client.DeleteAsync($"/api/user/delete/{id}");
            var responseContent = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                return Content(responseContent, "application/json");
            }

            return StatusCode((int)response.StatusCode, responseContent);
        }
    }
}
