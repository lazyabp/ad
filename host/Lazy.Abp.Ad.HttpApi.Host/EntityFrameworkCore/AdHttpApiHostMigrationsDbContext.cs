using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Ad.EntityFrameworkCore
{
    public class AdHttpApiHostMigrationsDbContext : AbpDbContext<AdHttpApiHostMigrationsDbContext>
    {
        public AdHttpApiHostMigrationsDbContext(DbContextOptions<AdHttpApiHostMigrationsDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ConfigureAd();
        }
    }
}
