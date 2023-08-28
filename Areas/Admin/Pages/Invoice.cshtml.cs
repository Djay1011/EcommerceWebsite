using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages
{
    public class InvoiceModel : PageModel
    {

        private DatabaseContext _db;

        public List<Invoice> invoices { get; set; }

        public InvoiceModel(DatabaseContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            invoices = _db.Invoices.OrderByDescending(o => o.Id).ToList();
        }
    }
}
