using Microsoft.EntityFrameworkCore;

namespace EFCoreScratchPad.Data
{
    public class ScratchPadContext : DbContext
    {
        public string ConnectionString { get; }

        public ScratchPadContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer($"Data Source={ConnectionString}");
    }
}
