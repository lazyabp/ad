using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace Lazy.Abp.Ad.MongoDB
{
    [ConnectionStringName(AdDbProperties.ConnectionStringName)]
    public class AdMongoDbContext : AbpMongoDbContext, IAdMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAd();
        }
    }
}