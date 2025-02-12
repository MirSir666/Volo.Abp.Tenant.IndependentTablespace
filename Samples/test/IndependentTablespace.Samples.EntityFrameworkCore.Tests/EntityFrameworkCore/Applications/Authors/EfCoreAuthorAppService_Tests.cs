using IndependentTablespace.Samples.Authors;
using Xunit;

namespace IndependentTablespace.Samples.EntityFrameworkCore.Applications.Authors;

[Collection(SamplesTestConsts.CollectionDefinitionName)]
public class EfCoreAuthorAppService_Tests : AuthorAppService_Tests<SamplesEntityFrameworkCoreTestModule>
{

}
