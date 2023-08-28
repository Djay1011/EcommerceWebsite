using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebAppli.Models;

namespace WebAppli.Areas.Admin.Pages.Shared
{
    public class InvoiceDetailsModel : PageModel
    {

        private DatabaseContext _db;

        public Invoice Invoices { get; set; }

        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public int InvoiceId { get; set; }
        public IList<InvoiceDetail> InvoiceDetails { get; set; }

        public decimal SubTotal { get; set; }
        public decimal Tax { get; internal set; }
        public decimal tax { get; set; }
        public decimal Total { get; set; }


        public InvoiceDetailsModel(DatabaseContext db)
        {
            _db = db;
        }

    
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Invoices = await _db.Invoices.FindAsync(id);
            InvoiceId = Id;

            if (Invoices == null)
            {
                return NotFound();
            }

            InvoiceDetails = await _db.InvoiceDetails
                .Where(d => d.InvoiceId == id)
                .Include(d => d.Product)
                .ToListAsync();
            SubTotal = Invoices.InvoiceDetails.Sum(i => i.Price * i.Quantity);
            Tax = 0.1m;
            tax = Invoices.InvoiceDetails.Sum(i => i.Price * i.Quantity * Tax);
            Total = Invoices.InvoiceDetails.Sum(i => i.Price * i.Quantity * (1 + Tax));


            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                var Invoices = _db.Invoices.Find(InvoiceId);
                Invoices.Status = 2;
                _db.SaveChanges();

            }
            catch
            {
                TempData["msg"] = "Failed. Please try again";
            }
            return RedirectToPage("Invoice");
        }



    }
}
