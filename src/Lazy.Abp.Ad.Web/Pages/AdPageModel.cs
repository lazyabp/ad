using Lazy.Abp.Ad.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Lazy.Abp.Ad.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class AdPageModel : AbpPageModel
    {
        protected AdPageModel()
        {
            LocalizationResourceType = typeof(AdResource);
            ObjectMapperContext = typeof(AdWebModule);
        }
    }
}