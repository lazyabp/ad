using Lazy.Abp.Ad.Localization;
using Volo.Abp.Application.Services;

namespace Lazy.Abp.Ad
{
    public abstract class AdAppService : ApplicationService
    {
        protected AdAppService()
        {
            LocalizationResource = typeof(AdResource);
            ObjectMapperContext = typeof(AdApplicationModule);
        }
    }
}
