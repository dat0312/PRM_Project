using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Web_App.Pages.Admin
{
    [Authorize]
    public class UsersModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
