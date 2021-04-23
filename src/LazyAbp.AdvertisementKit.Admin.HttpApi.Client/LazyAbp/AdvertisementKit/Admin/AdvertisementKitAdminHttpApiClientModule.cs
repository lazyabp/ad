using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit.Admin
{
    [DependsOn(
        typeof(AdvertisementKitAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AdvertisementKitAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(AdvertisementKitAdminApplicationContractsModule).Assembly,
                AdvertisementKitAdminRemoteServiceConsts.RemoteServiceName);
        }
    }
}
