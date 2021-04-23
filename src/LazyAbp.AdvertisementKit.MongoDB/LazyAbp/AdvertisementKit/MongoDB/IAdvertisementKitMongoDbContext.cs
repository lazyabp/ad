using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.AdvertisementKit.MongoDB
{
    [ConnectionStringName(AdvertisementKitDbProperties.ConnectionStringName)]
    public interface IAdvertisementKitMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
