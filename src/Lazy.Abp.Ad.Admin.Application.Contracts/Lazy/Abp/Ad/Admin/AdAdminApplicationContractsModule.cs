using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Modularity;

namespace Lazy.Abp.Ad.Admin
{
    [DependsOn(
        typeof(AdApplicationContractsModule),
        typeof(AdDomainSharedModule)
    )]
    public class AdAdminApplicationContractsModule : AbpModule
    {
    }
}
