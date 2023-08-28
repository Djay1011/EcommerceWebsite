using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
    public class CustomersModel : PageModel
    {

        private DatabaseContext _db;

        public List<Account> customers { get; set; }

        public CustomersModel(DatabaseContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            customers = _db.RoleAccounts.Where(a => a.RoleId == 2).Select(r => r.Account).ToList();
        }

        public IActionResult OnGetDelete(int id)
        {
            try
            {
                _db.Category.Remove(_db.Category.Find(id));
                _db.SaveChanges();

            }
            catch
            {
                TempData["msg"] = "Failed to Delete. Please try again";
            }
            return RedirectToPage("customers");
        }

    }
}
