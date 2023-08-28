using System;
using System.Collections.Generic;

namespace WebAppli.Models
{
    public partial class Role
    {
        public Role() 
        {
            RoleAccounts = new List<RoleAccount>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }

        public virtual ICollection<RoleAccount> RoleAccounts { get; set; }

    }
}
