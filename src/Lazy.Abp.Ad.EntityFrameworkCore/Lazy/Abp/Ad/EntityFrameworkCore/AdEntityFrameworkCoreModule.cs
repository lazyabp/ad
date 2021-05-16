using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Ad.EntityFrameworkCore
{
    [DependsOn(
        typeof(AdDomainModule),
        typeof(AbpEntityFrameworkCoreModule)
    )]
    public class AdEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AdDbContext>(options =>
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
