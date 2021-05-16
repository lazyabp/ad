using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Ad.Admin
{
    [DependsOn(
        typeof(AdAdminApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AdAdminHttpApiClientModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(typeof(AdAdminApplicationContractsModule).Assembly,
                AdAdminRemoteServiceConsts.RemoteServiceName);
        }
    }
}
