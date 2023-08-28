using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAppli.Models;

namespace WebAppli.Models
{
    public partial class Products
    {
        public Products() 
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
   
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string photo { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public bool Status { get; set; }
        public bool Featured { get; set; }
        public string Brand { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
    }
}
