using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
    public class AddProductModel : PageModel
    {
        private DatabaseContext _db;

        [BindProperty]
        public Products product { get; set; }

        public List<Category> Categories { get; set; }

        private IWebHostEnvironment _WebHost;

        public AddProductModel(DatabaseContext db, IWebHostEnvironment webHost)
        {
            _db = db;
            _WebHost = webHost;
        }
        public void OnGet()
        {
            product = new Products();
            Categories = _db.Category.Where(c => c.Id == null).ToList();

        }

        public IActionResult OnPost(Products product)
        {
            _db.Product.Add(product);
            _db.SaveChanges();
            return RedirectToPage("products");
        }



    }
}

