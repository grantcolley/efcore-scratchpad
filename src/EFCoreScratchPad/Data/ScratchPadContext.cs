using EFCoreScratchPad.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreScratchPad.Data
{
    public class ScratchPadContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Redress> Redresses { get; set; }

        public ScratchPadContext(DbContextOptions<ScratchPadContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<Customer>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Customer)
                .HasForeignKey(p => p.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Project>()
                .HasMany(p => p.Redresses)
                .WithOne(r => r.Project)
                .HasForeignKey(r => r.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Redress>()
                .HasOne(r => r.Product)
                .WithOne(p => p.Redress)
                .HasForeignKey<Redress>(r => r.ProductId)
                .HasPrincipalKey<Product>(p => p.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Redress>()
                .HasIndex(r => r.ProductId)
                .IsUnique();
        }
    }
}
