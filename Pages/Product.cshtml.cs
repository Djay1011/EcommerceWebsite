using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class ProductModel : PageModel
    {
        private DatabaseContext _db;

        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }
        public Category Category { get; set; }
        public List<Products> Products { get; set; }

        public ProductModel(DatabaseContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Category = _db.Category.Find(Id);
            Products = _db.Product.Where(p => p.Status).ToList();
        }
    }
}
