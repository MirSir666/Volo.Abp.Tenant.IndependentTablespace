using Volo.Abp.Modularity;

namespace IndependentTablespace.Samples;

public abstract class SamplesApplicationTestBase<TStartupModule> : SamplesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
