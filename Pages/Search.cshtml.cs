using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Pages
{
    public class SearchModel : PageModel
    {
        private DatabaseContext _db;


        public string SearchTerm { get; set; }
        public List<Products> product { get; set; }
        public SearchModel(DatabaseContext db)
        {
            _db = db;
        }

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                product = _db.Product
                    .Where(p => p.Name.Contains(searchTerm))
                    .ToList();
            }
        }
    }
}
