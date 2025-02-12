using Volo.Abp.Modularity;

namespace IndependentTablespace.Samples;

[DependsOn(
    typeof(SamplesApplicationModule),
    typeof(SamplesDomainTestModule)
)]
public class SamplesApplicationTestModule : AbpModule
{

}
