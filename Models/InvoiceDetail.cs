using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppli.Models
{
    public class InvoiceDetail
    {
        public int InvoiceId { get; set; }
        public int ProductId { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public virtual Invoice Invoice { get; set; }
        public virtual Products Product { get; set; }

    }

    
}
