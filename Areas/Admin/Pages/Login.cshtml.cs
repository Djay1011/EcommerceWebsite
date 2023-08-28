using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;
using WebAppli.Security;

namespace WebAppli.Areas.Admin.Pages
{
    public class LoginModel : PageModel
    {
        public string Msg { get; set; }
        
        private DatabaseContext _db;

        private SecurityManager securityManager = new SecurityManager();

        public LoginModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnGetLogout()
        {
            securityManager.SignOut(HttpContext);
            return RedirectToPage("Login");
        }

        public IActionResult OnPost(string username, string password)
        {
            Account account = Check(username, password);
            if (account != null)
            {
                securityManager.SignIn(HttpContext, account);
                return RedirectToPage("Dashboard");
            }
            else
            {
                Msg = "Invalid username or password, Please try again.";
                return Page();
            }
        }

        private Account Check(string username, string password)
        {
            Account account = _db.Accounts.SingleOrDefault(a => a.UserName.Equals(username));
            if (account != null)
            {
                var isAdmin = account.RoleAccounts.Count(ra => ra.RoleId == 1);
                if (BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }
    }
}
