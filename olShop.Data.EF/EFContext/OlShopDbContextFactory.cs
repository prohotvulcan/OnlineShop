using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace olShop.Data.EF.EFContext
{
    public class OlShopDbContextFactory : IDesignTimeDbContextFactory<OlShopDbContext>
    {
        public OlShopDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("olShopSolutionDb");
            var optionsBuilder = new DbContextOptionsBuilder<OlShopDbContext>();
            
            optionsBuilder.UseSqlServer(connectionString);

            return new OlShopDbContext(optionsBuilder.Options);
        }
    }
}
