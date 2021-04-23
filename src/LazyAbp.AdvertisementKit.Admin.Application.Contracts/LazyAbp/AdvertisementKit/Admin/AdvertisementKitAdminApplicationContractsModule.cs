using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace LazyAbp.AdvertisementKit.Admin
{
    [DependsOn(typeof(AdvertisementKitDomainSharedModule))]
    public class AdvertisementKitAdminApplicationContractsModule : AbpModule
    {
    }
}
