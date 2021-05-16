using Lazy.Abp.Ad.Localization;
using Localization.Resources.AbpUi;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Ad.Admin
{
    [DependsOn(
        typeof(AdAdminApplicationContractsModule),
        typeof(AbpAspNetCoreMvcModule))]
    public class AdAdminHttpApiModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            PreConfigure<IMvcBuilder>(mvcBuilder =>
            {
                mvcBuilder.AddApplicationPartIfNotExists(typeof(AdAdminHttpApiModule).Assembly);
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
