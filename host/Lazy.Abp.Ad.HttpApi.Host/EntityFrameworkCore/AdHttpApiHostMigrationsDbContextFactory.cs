using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Lazy.Abp.Ad.EntityFrameworkCore
{
    public class AdHttpApiHostMigrationsDbContextFactory : IDesignTimeDbContextFactory<AdHttpApiHostMigrationsDbContext>
    {
        public AdHttpApiHostMigrationsDbContext CreateDbContext(string[] args)
        {
            var configuration = BuildConfiguration();

            var builder = new DbContextOptionsBuilder<AdHttpApiHostMigrationsDbContext>()
                .UseSqlServer(configuration.GetConnectionString("Ad"));

            return new AdHttpApiHostMigrationsDbContext(builder.Options);
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false);

            return builder.Build();
        }
    }
}
