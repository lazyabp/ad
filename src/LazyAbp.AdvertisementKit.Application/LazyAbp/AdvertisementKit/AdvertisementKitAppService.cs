using LazyAbp.AdvertisementKit.Localization;
using Volo.Abp.Application.Services;

namespace LazyAbp.AdvertisementKit
{
    public abstract class AdvertisementKitAppService : ApplicationService
    {
        protected AdvertisementKitAppService()
        {
            LocalizationResource = typeof(AdvertisementKitResource);
            ObjectMapperContext = typeof(AdvertisementKitApplicationModule);
        }
    }
}
