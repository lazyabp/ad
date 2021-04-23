using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit.EntityFrameworkCore
{
    [DependsOn(
        typeof(AdvertisementKitDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AdvertisementKitEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AdvertisementKitDbContext>(options =>
            {
                /* Add custom repositories here. Example:
                 * options.AddRepository<Question, EfCoreQuestionRepository>();
                 */
                options.AddRepository<Advertising, AdvertisingRepository>();
                options.AddRepository<AdvertisingItem, AdvertisingItemRepository>();
                options.AddRepository<UserAdvertising, UserAdvertisingRepository>();
            });
        }
    }
}
