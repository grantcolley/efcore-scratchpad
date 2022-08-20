using EFCoreScratchPad.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Headway.Repository.Data
{
    /// <summary>
    /// 
    /// https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli
    /// 
    /// EF Core Tools commands (for example, the Migrations commands) require a derived DbContext 
    /// instance to be created at design time in order to gather details about the application's 
    /// entity types and how they map to a database schema.
    /// 
    /// DesignTimeDbContextFactory tells the tools how to create your DbContext.
    /// 
    /// </summary>
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ScratchPadContext>
    {
        public ScratchPadContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration
                = new ConfigurationBuilder().SetBasePath(
                    Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/../EFCoreScratchPad/appsettings.json").Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<ScratchPadContext>();
            builder.EnableSensitiveDataLogging(true);
            builder.UseSqlServer(connectionString);

            return new ScratchPadContext(builder.Options);
        }
    }
}
