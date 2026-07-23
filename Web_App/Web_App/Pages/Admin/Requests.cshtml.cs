using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class RequestsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
