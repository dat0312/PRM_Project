using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class GradesModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
