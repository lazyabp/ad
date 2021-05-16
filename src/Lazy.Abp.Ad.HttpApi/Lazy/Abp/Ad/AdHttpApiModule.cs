using Localization.Resources.AbpUi;
using Lazy.Abp.Ad.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Lazy.Abp.Ad
{
    [DependsOn(
        typeof(AdApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AdHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AdHttpApiModule).Assembly);
            });
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpLocalizationOptions>(options =>
            {
                options.Resources
                    .Get<AdResource>()
                    .AddBaseTypes(typeof(AbpUiResource));
            });
        }
    }
}
