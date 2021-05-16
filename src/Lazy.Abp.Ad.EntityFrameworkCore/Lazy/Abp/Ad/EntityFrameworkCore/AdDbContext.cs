using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Ad.EntityFrameworkCore
{
    [ConnectionStringName(AdDbProperties.ConnectionStringName)]
    public class AdDbContext : AbpDbContext<AdDbContext>, IAdDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Advertising> Advertisings { get; set; }
        public DbSet<AdvertisingItem> AdvertisingItems { get; set; }
        public DbSet<UserAdvertising> UserAdvertisings { get; set; }

        public AdDbContext(DbContextOptions<AdDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureAd();
        }
    }
}
