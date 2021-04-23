using Localization.Resources.AbpUi;
using LazyAbp.AdvertisementKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AdvertisementKitApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AdvertisementKitHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AdvertisementKitHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AdvertisementKitResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
