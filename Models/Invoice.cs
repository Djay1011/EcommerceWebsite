using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppli.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            InvoiceDetails = new HashSet<InvoiceDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Created { get; set; }
        public int? Status { get; set; }
        public int? AccountId { get; set; }


        public virtual Account Account { get; set; }
        public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; }
        
    }
}
