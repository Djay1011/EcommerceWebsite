using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppli.Models
{
    public partial class Account
    {
        public Account()
        {
            invoice = new HashSet<Invoice>();
            RoleAccounts = new HashSet<RoleAccount>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }
        public virtual ICollection<Invoice> invoice { get; set; }
    }
}
