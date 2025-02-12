using IndependentTablespace.Samples.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace IndependentTablespace.Samples.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class SamplesPageModel : AbpPageModel
{
    protected SamplesPageModel()
    {
        LocalizationResourceType = typeof(SamplesResource);
    }
}
