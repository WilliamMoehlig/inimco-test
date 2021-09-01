using DevTest.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace DevTest.Tests.Utilities
{

    public class TestDataContext : DevTestContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");

            var connectionString = builder.Build().GetConnectionString("DevTestDatabase");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
