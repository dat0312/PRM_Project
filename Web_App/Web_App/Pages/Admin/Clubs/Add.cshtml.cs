using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;

namespace Web_App.Pages.Admin.Clubs
{
    public class AddModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;

        public AddModel(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [BindProperty(SupportsGet = true)]
        public int? Id { get; set; } // Null if creating new

        [BindProperty]
        public string Name { get; set; } = "";
        
        [BindProperty]
        public string Description { get; set; } = "";
        
        [BindProperty]
        public string Type { get; set; } = "Nghệ thuật & Văn hóa";
        
        [BindProperty]
        public string Status { get; set; } = "HOẠT ĐỘNG";
        
        [BindProperty]
        public int? PresidentId { get; set; }

        public List<UserViewModel> Users { get; set; } = new List<UserViewModel>();

        public async Task<IActionResult> OnGetAsync()
        {
            ViewData["ActiveMenu"] = "Clubs";
            ViewData["Title"] = Id.HasValue ? "Sửa câu lạc bộ" : "Thêm câu lạc bộ mới";

            var client = _clientFactory.CreateClient("BackendApi");

            // Fetch users for dropdown/autocomplete
            try
            {
                var usersResponse = await client.GetAsync("/api/user/users");
                if (usersResponse.IsSuccessStatusCode)
                {
                    var usersContent = await usersResponse.Content.ReadAsStringAsync();
                    var allUsers = JsonSerializer.Deserialize<List<UserViewModel>>(usersContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (allUsers != null) Users = allUsers;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching users: {ex.Message}");
            }

            // If Edit mode, fetch club details
            if (Id.HasValue)
            {
                try
                {
                    var clubResponse = await client.GetAsync("/api/club");
                    if (clubResponse.IsSuccessStatusCode)
                    {
                        var clubContent = await clubResponse.Content.ReadAsStringAsync();
                        var allClubs = JsonSerializer.Deserialize<List<ClubDetailViewModel>>(clubContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                        var club = allClubs?.FirstOrDefault(c => c.Id == Id.Value);
                        if (club != null)
                        {
                            Name = club.Name;
                            Description = club.Description;
                            Type = club.Type;
                            Status = club.Status;
                            PresidentId = club.PresidentId;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error fetching club details: {ex.Message}");
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(Name))
            {
                ModelState.AddModelError(string.Empty, "Vui lòng nhập tên câu lạc bộ");
                // Need to re-fetch users on error
                return await OnGetAsync();
            }

            var client = _clientFactory.CreateClient("BackendApi");

            var payload = new
            {
                Name = Name,
                Type = Type,
                Status = Status,
                Description = Description,
                PresidentId = PresidentId
            };
            
            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");

            HttpResponseMessage response;
            try
            {
                if (Id.HasValue)
                {
                    // Update
                    response = await client.PutAsync($"/api/club/update/{Id.Value}", content);
                }
                else
                {
                    // Create
                    response = await client.PostAsync("/api/club/add", content);
                }

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToPage("/Admin/Clubs/Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Có lỗi xảy ra khi lưu.");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Lỗi kết nối: {ex.Message}");
            }

            // If error, return to page
            return await OnGetAsync();
        }
    }

    public class UserViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
    }

    public class ClubDetailViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";
        public string Description { get; set; } = "";
        public int? PresidentId { get; set; }
    }
}
