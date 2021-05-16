using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Lazy.Abp.Ad.EntityFrameworkCore
{
    [ConnectionStringName(AdDbProperties.ConnectionStringName)]
    public interface IAdDbContext : IEfCoreDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * DbSet<Question> Questions { get; }
         */
        DbSet<Advertising> Advertisings { get; set; }
        DbSet<AdvertisingItem> AdvertisingItems { get; set; }
        DbSet<UserAdvertising> UserAdvertisings { get; set; }
    }
}
