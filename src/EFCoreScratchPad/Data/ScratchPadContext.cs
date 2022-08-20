using EFCoreScratchPad.Model;
using Microsoft.EntityFrameworkCore;

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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Project>()
                .HasIndex(p => p.Name)
                .IsUnique();

            builder.Entity<Redress>()
                .HasOne(r => r.Product)
                .WithOne(p => p.Redress)
                .HasForeignKey<Product>(p => p.RedressId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
