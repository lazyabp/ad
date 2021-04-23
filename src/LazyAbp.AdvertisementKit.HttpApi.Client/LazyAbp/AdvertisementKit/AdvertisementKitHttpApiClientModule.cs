using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AdvertisementKitApplicationContractsModule),
        typeof(AbpHttpClientModule))]
    public class AdvertisementKitHttpApiClientModule : AbpModule
    {
        public const string RemoteServiceName = "AdvertisementKit";

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddHttpClientProxies(
                typeof(AdvertisementKitApplicationContractsModule).Assembly,
                RemoteServiceName
            );
        }
    }
}
