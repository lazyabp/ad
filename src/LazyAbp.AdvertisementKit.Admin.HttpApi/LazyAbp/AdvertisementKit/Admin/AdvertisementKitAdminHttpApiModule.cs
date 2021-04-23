using LazyAbp.AdvertisementKit.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit.Admin
{
    [DependsOn(
        typeof(AdvertisementKitAdminApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AdvertisementKitAdminHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AdvertisementKitAdminHttpApiModule).Assembly);
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
