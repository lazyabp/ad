using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;
using Volo.Abp;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AdvertisementKitDomainModule),
        typeof(AdvertisementKitApplicationContractsModule),
        typeof(AbpDddApplicationModule),
        typeof(AbpAutoMapperModule)
        )]
    public class AdvertisementKitApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AdvertisementKitApplicationModule>();
            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddMaps<AdvertisementKitApplicationModule>(validate: true);
            });
        }
    }
}
