using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class ProfileModel : PageModel
    {

        private DatabaseContext _db;

        [BindProperty]
        public Account account { get; set; }

        public ProfileModel(DatabaseContext db)
        {
            _db = db;
        }

        public IActionResult OnGet()
        {
            string usernameSession = HttpContext.Session.GetString("username");
            if (usernameSession != null)
            {
                account = _db.Accounts.SingleOrDefault(a => a.UserName.Equals(usernameSession));
                return Page();
            }
            else
            {
                return RedirectToPage("Login");
            }
            
        }

        public IActionResult OnPost()
        {
            if(string.IsNullOrEmpty(account.Password))
            {
                account.Password = _db.Accounts.AsNoTracking().SingleOrDefault(a => a.Id == account.Id).Password;
            }
            else
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            
            account.Status = true;
            _db.Entry(account).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("profile");
        }
    }
}
