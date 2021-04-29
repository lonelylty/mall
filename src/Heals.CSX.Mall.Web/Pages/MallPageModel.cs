using Heals.CSX.Mall.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Heals.CSX.Mall.Web.Pages
{
    /* Inherit your PageModel classes from this class.
     */
    public abstract class MallPageModel : AbpPageModel
    {
        protected MallPageModel()
        {
            LocalizationResourceType = typeof(MallResource);
        }
    }
}