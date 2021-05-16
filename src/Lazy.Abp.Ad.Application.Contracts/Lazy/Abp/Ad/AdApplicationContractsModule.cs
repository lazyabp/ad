using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Lazy.Abp.Ad
{
    [DependsOn(
        typeof(AdDomainSharedModule),
        typeof(AbpDddApplicationContractsModule),
        typeof(AbpAuthorizationModule)
        )]
    public class AdApplicationContractsModule : AbpModule
    {

    }
}
