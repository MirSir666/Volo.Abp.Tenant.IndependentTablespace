using Xunit;

namespace IndependentTablespace.Samples.EntityFrameworkCore;

[CollectionDefinition(SamplesTestConsts.CollectionDefinitionName)]
public class SamplesEntityFrameworkCoreCollection : ICollectionFixture<SamplesEntityFrameworkCoreFixture>
{

}
