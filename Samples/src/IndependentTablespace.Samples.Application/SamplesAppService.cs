using System;
using System.Collections.Generic;
using System.Text;
using IndependentTablespace.Samples.Localization;
using Volo.Abp.Application.Services;

namespace IndependentTablespace.Samples;

/* Inherit your application services from this class.
 */
public abstract class SamplesAppService : ApplicationService
{
    protected SamplesAppService()
    {
        LocalizationResource = typeof(SamplesResource);
    }
}
