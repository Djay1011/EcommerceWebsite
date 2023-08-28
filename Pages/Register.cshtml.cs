using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class RegisterModel : PageModel
    {
        private DatabaseContext _db;

        [BindProperty]
        public Account account { get; set; }
        public RegisterModel(DatabaseContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            account = new Account();
        }

        public IActionResult OnPost()
        {
            account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            account.Status = true;
            _db.Accounts.Add(account);
            _db.SaveChanges();
            RoleAccount roleAccount = new RoleAccount 
            {
                AccountId = account.Id,
                RoleId = 2,
                Status = true
            };
            _db.RoleAccounts.Add(roleAccount);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
