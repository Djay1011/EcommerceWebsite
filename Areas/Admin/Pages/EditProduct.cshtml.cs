using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
    public class EditProductModel : PageModel
    {

        private DatabaseContext _db;

        [BindProperty]
        public Products product { get; set; }

        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }
        public List<Category> Categories { get; set; }

        public EditProductModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            product = _db.Product.Find(Id);
            Categories = _db.Category.Where(c => c.Name == null).ToList();
        }

        public IActionResult OnPost(Products product)
        {
            _db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            return RedirectToPage("Products");
        }
    }
}
