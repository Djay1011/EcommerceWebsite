using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAppli.Models
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext() 
        { 
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        { 
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Products> Product { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoleAccount> RoleAccounts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvoiceDetail>()
                .HasKey(id => new { id.InvoiceId, id.ProductId });

            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(id => id.Invoice)
                .WithMany(inv => inv.InvoiceDetails)
                .HasForeignKey(id => id.InvoiceId);

            modelBuilder.Entity<InvoiceDetail>()
                .HasOne(id => id.Product)
                .WithMany(prod => prod.InvoiceDetails)
                .HasForeignKey(id => id.ProductId);

            modelBuilder.Entity<RoleAccount>()
                .HasKey(ra => new { ra.RoleId, ra.AccountId });

            modelBuilder.Entity<RoleAccount>()
                .HasOne(ra => ra.Role)
                .WithMany(r => r.RoleAccounts)
                .HasForeignKey(ra => ra.RoleId);

            modelBuilder.Entity<RoleAccount>()
                .HasOne(ra => ra.Account)
                .WithMany(a => a.RoleAccounts)
                .HasForeignKey(ra => ra.AccountId);
        }
    }
}
