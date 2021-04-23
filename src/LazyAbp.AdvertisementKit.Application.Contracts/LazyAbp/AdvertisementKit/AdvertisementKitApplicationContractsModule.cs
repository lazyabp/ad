using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace LazyAbp.AdvertisementKit
{
    [DependsOn(
        typeof(AdvertisementKitDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AdvertisementKitApplicationContractsModule : AbpModule
    {

    }
}
