using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace IndependentTablespace.Samples.Web;

[Dependency(ReplaceServices = true)]
public class SamplesBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "Samples";
}
