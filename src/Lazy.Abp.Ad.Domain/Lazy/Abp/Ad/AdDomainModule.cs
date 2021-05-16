using Volo.Abp.Domain;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Ad
{
    [DependsOn(
        typeof(AbpDddDomainModule),
        typeof(AdDomainSharedModule)
    )]
    public class AdDomainModule : AbpModule
    {

    }
}
