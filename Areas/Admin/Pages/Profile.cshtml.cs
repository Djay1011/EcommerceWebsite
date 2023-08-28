using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
 
    public class ProfileModel : PageModel
    {
        private DatabaseContext _db;

        [BindProperty]
        public Account Account { get; set; }

        public ProfileModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            var username = User.FindFirst(ClaimTypes.Name).Value;
            Account = _db.Accounts.SingleOrDefault(a => a.UserName.Equals(username));
        }

        public IActionResult OnPost(Account account)
        {
            var currentAccount = _db.Accounts.AsNoTracking().SingleOrDefault(a => a.Id == account.Id);
            if(string.IsNullOrEmpty(account.Password))
            {
                account.Password = currentAccount.Password;
            }
            else
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            _db.Entry(account).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToPage("Profile");
        }
    }
}
