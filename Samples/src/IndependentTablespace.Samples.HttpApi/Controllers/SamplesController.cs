using IndependentTablespace.Samples.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace IndependentTablespace.Samples.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class SamplesController : AbpControllerBase
{
    protected SamplesController()
    {
        LocalizationResource = typeof(SamplesResource);
    }
}
