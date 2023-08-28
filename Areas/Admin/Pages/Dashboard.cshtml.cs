using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
    
    public class DashboardModel : PageModel
    {

        private DatabaseContext _db;

        public List<Products> Products { get; set; }

        public DashboardModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Products = _db.Product.ToList();
        }

        public IActionResult OnGetDelete(int id)
        {
            try
            {
                _db.Product.Remove(_db.Product.Find(id));
                _db.SaveChanges();

            }
            catch (Exception ex)
            {
                TempData["msg"] = "Failed to Delete. Please try again";
            }
            return RedirectToPage("Products");
        }
    }
}
