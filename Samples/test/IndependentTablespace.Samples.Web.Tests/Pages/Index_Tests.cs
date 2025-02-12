using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace IndependentTablespace.Samples.Pages;

public class Index_Tests : SamplesWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
