using Microsoft.AspNetCore.Builder;
using IndependentTablespace.Samples;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();
await builder.RunAbpModuleAsync<SamplesWebTestModule>();

public partial class Program
{
}
