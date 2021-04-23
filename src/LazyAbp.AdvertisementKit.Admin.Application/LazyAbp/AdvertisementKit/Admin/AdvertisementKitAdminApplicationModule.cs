using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.AutoMapper;
using Volo.Abp.Caching;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit.Admin
{
    [DependsOn(
        typeof(AdvertisementKitDomainModule),
        typeof(AdvertisementKitAdminApplicationContractsModule),
        typeof(AbpCachingModule),
        typeof(AbpAutoMapperModule))]
    public class AdvertisementKitAdminApplicationModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAutoMapperObjectMapper<AdvertisementKitAdminApplicationModule>();

            Configure<AbpAutoMapperOptions>(options =>
            {
                options.AddProfile<AdvertisementKitAdminApplicationAutoMapperProfile>(validate: true);
            });
        }
    }
}
