using Lazy.Abp.Ad.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Ad.Admin
{
    public abstract class AdAdminAppServiceBase : ApplicationService
    {
        protected AdAdminAppServiceBase()
        {
            ObjectMapperContext = typeof(AdAdminApplicationModule);
            LocalizationResource = typeof(AdResource);
        }
    }
}
