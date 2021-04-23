using LazyAbp.AdvertisementKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace LazyAbp.AdvertisementKit
{
    public abstract class AdvertisementKitController : AbpController
    {
        protected AdvertisementKitController()
        {
            LocalizationResource = typeof(AdvertisementKitResource);
        }
    }
}
