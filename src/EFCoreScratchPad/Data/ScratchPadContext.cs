using Microsoft.EntityFrameworkCore;

namespace EFCoreScratchPad.Data
{
    public class ScratchPadContext : DbContext
    {
        public string ConnectionString { get; }

        public ScratchPadContext()
        {
            ConnectionString = String.Empty;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source={ConnectionString}");
    }
}
