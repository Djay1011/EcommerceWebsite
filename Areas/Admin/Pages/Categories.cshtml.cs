using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
    public class CategoriesModel : PageModel
    {
        private DatabaseContext _db;

        public List<Category> Categories;

        public CategoriesModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            Categories = _db.Category.Where(c => c.Name == null).ToList();
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
            return RedirectToPage("Categories");
        }


    }
}
