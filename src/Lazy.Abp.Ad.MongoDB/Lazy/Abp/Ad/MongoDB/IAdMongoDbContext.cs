using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Ad.MongoDB
{
    [ConnectionStringName(AdDbProperties.ConnectionStringName)]
    public interface IAdMongoDbContext : IAbpMongoDbContext
    {
        /* Define mongo collections here. Example:
         * IMongoCollection<Question> Questions { get; }
         */
    }
}
