using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace LazyAbp.AdvertisementKit.MongoDB
{
    [ConnectionStringName(AdvertisementKitDbProperties.ConnectionStringName)]
    public class AdvertisementKitMongoDbContext : AbpMongoDbContext, IAdvertisementKitMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureAdvertisementKit();
        }
    }
}