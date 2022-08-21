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

            builder.Entity<Customer>()
                .HasMany(c => c.Redresses)
                .WithOne(r => r.Customer)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Product>()
                .HasOne(p => p.Redress)
                .WithOne(r => r.Product)
                .HasForeignKey<Redress>(r => r.ProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
