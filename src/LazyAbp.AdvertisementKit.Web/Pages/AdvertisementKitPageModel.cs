using LazyAbp.AdvertisementKit.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace LazyAbp.AdvertisementKit.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AdvertisementKitPageModel : AbpPageModel
    {
        protected AdvertisementKitPageModel()
        {
            LocalizationResourceType = typeof(AdvertisementKitResource);
            ObjectMapperContext = typeof(AdvertisementKitWebModule);
        }
    }
}