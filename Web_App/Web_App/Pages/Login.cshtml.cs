using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Web_App.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public string Phone { get; set; } = string.Empty;

        [BindProperty]
        public string Password { get; set; } = string.Empty;

        [TempData]
        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var client = _httpClientFactory.CreateClient("BackendApi");
            
            var loginDto = new { PhoneNumber = Phone, Password = Password };
            var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");

            try 
            {
                var response = await client.PostAsync("/api/Auth/login", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                    var authResult = JsonSerializer.Deserialize<AuthResponse>(responseContent, options);

                    if (authResult != null)
                    {
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, authResult.Id.ToString()),
                            new Claim(ClaimTypes.Name, authResult.PhoneNumber ?? ""),
                            new Claim("UserEmail", authResult.Email ?? "Chưa cập nhật"),
                            new Claim("UserPhone", authResult.PhoneNumber ?? "Chưa cập nhật"),
                            new Claim("FullName", authResult.FullName ?? ""),
                            new Claim("Token", authResult.Token ?? "")
                        };

                        if (authResult.Roles != null)
                        {
                            foreach (var role in authResult.Roles)
                            {
                                claims.Add(new Claim(ClaimTypes.Role, role));
                            }
                        }

                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                        await HttpContext.SignInAsync(
                            CookieAuthenticationDefaults.AuthenticationScheme, 
                            new ClaimsPrincipal(claimsIdentity));

                        if (authResult.Roles != null && authResult.Roles.Contains("Admin"))
                        {
                            return RedirectToPage("/Admin/Users");
                        }
                        else if (authResult.Roles != null && authResult.Roles.Contains("Teacher"))
                        {
                            return RedirectToPage("/Teacher/Schedule/Index");
                        }

                        return RedirectToPage("/Admin/Users");
                    }
                }
            } 
            catch (Exception)
            {
                ErrorMessage = "Không thể kết nối đến máy chủ. Vui lòng kiểm tra lại Backend.";
                return Page();
            }
            
            ErrorMessage = "Số điện thoại hoặc mật khẩu không chính xác.";
            return Page();
        }

        private class AuthResponse
        {
            public int Id { get; set; }
            public string Token { get; set; }
            public string PhoneNumber { get; set; }
            public string Email { get; set; }
            public string FullName { get; set; }
            public string StudentId { get; set; }
            public string ClassName { get; set; }
            public string AvatarUrl { get; set; }
            public List<string> Roles { get; set; }
        }
    }
}
