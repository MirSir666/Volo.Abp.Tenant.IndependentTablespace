using Volo.Abp.Modularity;

namespace IndependentTablespace.Samples;

[DependsOn(
    typeof(SamplesDomainModule),
    typeof(SamplesTestBaseModule)
)]
public class SamplesDomainTestModule : AbpModule
{

}
