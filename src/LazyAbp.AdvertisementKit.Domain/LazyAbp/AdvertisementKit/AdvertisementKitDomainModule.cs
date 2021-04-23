using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AdvertisementKitDomainSharedModule)
    )]
    public class AdvertisementKitDomainModule : AbpModule
    {

    }
}
