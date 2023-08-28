using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class ProductDetailsModel : PageModel
    {
        private DatabaseContext _db;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public string MainImage { get; set; }
        public string[] RelatedImages { get; set; }
        public string Description { get; set; }
        public List<Products> SuggestedProducts { get; set; }



        public ProductDetailsModel(DatabaseContext db)
        {
            _db = db;
        }


        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _db.Product
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            Id = product.Id;
            Brand = product.Brand;
            Name = product.Name;
            Price = product.Price;
            MainImage = product.photo;
            RelatedImages = new string[] { "~/Product/af1 1.png", "../img/af1 2.png", "../img/af1 3.png", "../img/af1 3.png" };
            Description = product.Description;

            SuggestedProducts = await _db.Product
                .Where(p => p.CategoryId == product.CategoryId && p.Id != product.Id).Take(4).ToListAsync();

            return Page();
        }


    }
}



