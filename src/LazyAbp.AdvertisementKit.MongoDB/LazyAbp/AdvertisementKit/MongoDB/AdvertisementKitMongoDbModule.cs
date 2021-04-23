using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.MongoDB;

namespace LazyAbp.AdvertisementKit.MongoDB
{
    [DependsOn(
        typeof(AdvertisementKitDomainModule),
        typeof(AbpMongoDbModule)
        )]
    public class AdvertisementKitMongoDbModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddMongoDbContext<AdvertisementKitMongoDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, MongoQuestionRepository>();
                 */
            });
        }
    }
}
