using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AdvertisementKitApplicationModule),
        typeof(AdvertisementKitDomainTestModule)
        )]
    public class AdvertisementKitApplicationTestModule : AbpModule
    {

    }
}
