using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Web_App.Pages.Admin.Clubs
{
    public class IndexModel : PageModel
    {
        private readonly IHttpClientFactory _clientFactory;
        public string BackendApiUrl { get; set; } = "";

        public IndexModel(IHttpClientFactory clientFactory, IConfiguration configuration)
        {
            _clientFactory = clientFactory;
            BackendApiUrl = configuration["BackendApiUrl"] ?? "https://localhost:7242";
        }

        public List<ClubViewModel> Clubs { get; set; } = new List<ClubViewModel>();
        public List<ProposalViewModel> Proposals { get; set; } = new List<ProposalViewModel>();
        public ClubStatsViewModel Stats { get; set; } = new ClubStatsViewModel();

        [BindProperty(SupportsGet = true)]
        public string? SearchQuery { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SelectedType { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? SelectedStatus { get; set; }

        public async Task OnGetAsync()
        {
            ViewData["ActiveMenu"] = "Clubs";
            ViewData["Title"] = "Quản lý Câu lạc bộ";

            var client = _clientFactory.CreateClient("BackendApi");

            try
            {
                // Fetch Clubs
                var clubsResponse = await client.GetAsync("/api/club");
                if (clubsResponse.IsSuccessStatusCode)
                {
                    var clubsContent = await clubsResponse.Content.ReadAsStringAsync();
                    var allClubs = JsonSerializer.Deserialize<List<ClubViewModel>>(clubsContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    
                    if (allClubs != null)
                    {
                        Clubs = allClubs.Where(c => 
                            (string.IsNullOrEmpty(SearchQuery) || c.Name.Contains(SearchQuery, StringComparison.OrdinalIgnoreCase)) &&
                            (string.IsNullOrEmpty(SelectedType) || SelectedType == "Tất cả các loại" || c.Type == SelectedType) &&
                            (string.IsNullOrEmpty(SelectedStatus) || SelectedStatus == "Tất cả trạng thái" || c.Status == SelectedStatus)
                        ).ToList();
                    }
                }

                // Fetch Stats
                var statsResponse = await client.GetAsync("/api/club/stats");
                if (statsResponse.IsSuccessStatusCode)
                {
                    var statsContent = await statsResponse.Content.ReadAsStringAsync();
                    Stats = JsonSerializer.Deserialize<ClubStatsViewModel>(statsContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new ClubStatsViewModel();
                }

                // Fetch Proposals
                var proposalsResponse = await client.GetAsync("/api/AppRequest");
                if (proposalsResponse.IsSuccessStatusCode)
                {
                    var proposalsContent = await proposalsResponse.Content.ReadAsStringAsync();
                    var allProposals = JsonSerializer.Deserialize<List<ProposalViewModel>>(proposalsContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                    if (allProposals != null)
                    {
                        Proposals = allProposals.Where(p => p.Status == "Chờ duyệt").ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var client = _clientFactory.CreateClient("BackendApi");
            await client.DeleteAsync($"/api/club/delete/{id}");
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostApproveProposalAsync(int id)
        {
            var client = _clientFactory.CreateClient("BackendApi");
            await client.PostAsync($"/api/AppRequest/{id}/approve", null);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRejectProposalAsync(int id)
        {
            var client = _clientFactory.CreateClient("BackendApi");
            await client.PostAsync($"/api/AppRequest/{id}/reject", null);
            return RedirectToPage();
        }
    }

    public class ClubViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Code { get; set; } = "";
        public string Type { get; set; } = "";
        public string Status { get; set; } = "";
        public string Description { get; set; } = "";
        public string? PresidentName { get; set; }
        public int? PresidentId { get; set; }
        public int MemberCount { get; set; }
    }

    public class ClubStatsViewModel
    {
        public int TotalClubs { get; set; }
        public int ActiveClubs { get; set; }
        public int PausedClubs { get; set; }
        public int TotalMembers { get; set; }
    }

    public class ProposalViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string Status { get; set; } = "";
        public string SenderName { get; set; } = "";
        public string SenderCode { get; set; } = "";
        public string Date { get; set; } = "";
    }
}
