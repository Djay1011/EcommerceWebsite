using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class InvoiceMangementModel : PageModel
    {
        private DatabaseContext _db;
        public List<Invoice> invoices {  get; set; }

        public InvoiceMangementModel(DatabaseContext db)
        {
                _db = db;
        }
        public IActionResult OnGet()
        {
            string username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToPage("Login");
            }
            else
            {
                var account = _db.Accounts.AsNoTracking().SingleOrDefault(a => a.UserName == (username));
                invoices = _db.Invoices.Where(i => i.AccountId == account.Id).OrderByDescending(i => i.Id).ToList();
                return Page();
            }
        }
    }
}
