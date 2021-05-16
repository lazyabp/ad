using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Ad
{
    [DependsOn(
        typeof(AdApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AdHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "Ad";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AdApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
