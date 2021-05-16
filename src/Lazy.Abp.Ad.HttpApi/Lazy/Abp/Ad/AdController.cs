using Lazy.Abp.Ad.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Lazy.Abp.Ad
{
    public abstract class AdController : AbpController
    {
        protected AdController()
        {
            LocalizationResource = typeof(AdResource);
        }
    }
}
