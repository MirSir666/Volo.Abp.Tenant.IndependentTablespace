using IndependentTablespace.Samples.Samples;
using Xunit;

namespace IndependentTablespace.Samples.EntityFrameworkCore.Applications;

[Collection(SamplesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<SamplesEntityFrameworkCoreTestModule>
{

}
