using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace LazyAbp.AdvertisementKit.EntityFrameworkCore
{
    [ConnectionStringName(AdvertisementKitDbProperties.ConnectionStringName)]
    public class AdvertisementKitDbContext : AbpDbContext<AdvertisementKitDbContext>, IAdvertisementKitDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<AdvertisingItem> AdvertisingItems { get; set; }
        public DbSet<UserAdvertising> UserAdvertisings { get; set; }

        public AdvertisementKitDbContext(DbContextOptions<AdvertisementKitDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAdvertisementKit();
        }
    }
}
