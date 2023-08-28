using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebAppli.Helpers;
using WebAppli.Models;
using Microsoft.EntityFrameworkCore;



namespace WebAppli.Pages
{
    public class InvoiceDetailModel : PageModel
    {
        
        private DatabaseContext _db;


        [BindProperty(Name = "id", SupportsGet = true)]
        public int Id { get; set; }
        public Invoice Invoice { get; set; }
        public IList<InvoiceDetail> InvoiceDetails { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Tax { get; internal set; }
        public decimal tax { get; set; }
        public decimal Total { get; set; }


        public InvoiceDetailModel(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Invoice = await _db.Invoices.FindAsync(id);

            if (Invoice == null)
            {
                return NotFound();
            }

            InvoiceDetails = await _db.InvoiceDetails
                .Where(d => d.InvoiceId == id)
                .Include(d => d.Product)
                .ToListAsync();
            SubTotal = Invoice.InvoiceDetails.Sum(i => i.Price * i.Quantity);
            Tax = 0.1m;
            tax = Invoice.InvoiceDetails.Sum(i => i.Price * i.Quantity * Tax);
            Total = Invoice.InvoiceDetails.Sum(i => i.Price * i.Quantity * (1 + Tax));


            return Page();
        }
    }
}
