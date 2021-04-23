using LazyAbp.AdvertisementKit.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit
{
    /* Domain tests are configured to use the EF Core provider.
     * You can switch to MongoDB, however your domain tests should be
     * database independent anyway.
     */
    [DependsOn(
        typeof(AdvertisementKitEntityFrameworkCoreTestModule)
        )]
    public class AdvertisementKitDomainTestModule : AbpModule
    {
        
    }
}
