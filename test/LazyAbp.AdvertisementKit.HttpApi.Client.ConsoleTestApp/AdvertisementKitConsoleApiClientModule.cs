using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AdvertisementKitHttpApiClientModule),
        typeof(AbpHttpClientIdentityModelModule)
        )]
    public class AdvertisementKitConsoleApiClientModule : AbpModule
    {
        
    }
}
