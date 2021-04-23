using LazyAbp.AdvertisementKit.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Services;

namespace LazyAbp.AdvertisementKit.Admin
{
    public abstract class AdvertisementKitAdminAppServiceBase : ApplicationService
    {
        protected AdvertisementKitAdminAppServiceBase()
        {
            ObjectMapperContext = typeof(AdvertisementKitAdminApplicationModule);
            LocalizationResource = typeof(AdvertisementKitResource);
        }
    }
}
