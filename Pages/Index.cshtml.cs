using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class IndexModel : PageModel
    {
        private DatabaseContext _db;
        public List<Products> featuredProducts { get; set; }
        public List<Products> OtherProducts { get; set; }
        public Products Product { get; set; }

        public IndexModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            featuredProducts = _db.Product.Where(p => p.Featured && p.Status).OrderByDescending(p => p.Id).Take(6).ToList();
            OtherProducts = _db.Product.Where(p => p.Status).OrderByDescending(p => p.Id).Take(4).ToList();
        }
    }
}
