using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class LoginModel : PageModel
    {
        private DatabaseContext _db;
        public string Msg { get; set; }
        

        public LoginModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }

        public IActionResult OnPost(string username,string password)
        {
            if (Check(username, password) != null)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToPage("Welcome");
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
                if(BCrypt.Net.BCrypt.Verify(password, account.Password))
                {
                    return account;
                }
            }
            return null;
        }
    }
}
