using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppli.Pages
{
    public class WelcomeModel : PageModel
    {
        public String Username { get; set; }
        public IActionResult OnGet()
        {
            string usernameSession = HttpContext.Session.GetString("username");
            if (usernameSession == null)
            {
                return RedirectToPage("login");
            }
            else
            {
                Username = usernameSession;
                return Page();
            }
        }
    }
}
