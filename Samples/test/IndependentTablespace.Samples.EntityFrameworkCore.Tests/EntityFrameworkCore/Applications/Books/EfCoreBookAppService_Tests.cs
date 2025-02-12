using IndependentTablespace.Samples.Books;
using Xunit;

namespace IndependentTablespace.Samples.EntityFrameworkCore.Applications.Books;

[Collection(SamplesTestConsts.CollectionDefinitionName)]
public class EfCoreBookAppService_Tests : BookAppService_Tests<SamplesEntityFrameworkCoreTestModule>
{

}
