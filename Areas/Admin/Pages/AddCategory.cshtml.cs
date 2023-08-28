using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
    public class AddCategoryModel : PageModel
    {
        private DatabaseContext _db;

        [BindProperty]
        public Category category { get; set; }

        public AddCategoryModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            category = new Category()
            {
                Status = true
            };
        }

        public IActionResult OnPost(Category category)
        {
            _db.Category.Add(category);
            _db.SaveChanges();
            return RedirectToPage("Categories");
        }
    }
}
