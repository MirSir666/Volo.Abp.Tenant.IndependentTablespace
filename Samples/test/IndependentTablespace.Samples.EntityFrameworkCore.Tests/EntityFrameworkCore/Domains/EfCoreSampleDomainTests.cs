using IndependentTablespace.Samples.Samples;
using Xunit;

namespace IndependentTablespace.Samples.EntityFrameworkCore.Domains;

[Collection(SamplesTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<SamplesEntityFrameworkCoreTestModule>
{

}
