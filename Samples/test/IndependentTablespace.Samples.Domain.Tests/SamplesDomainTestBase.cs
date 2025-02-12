using Volo.Abp.Modularity;

namespace IndependentTablespace.Samples;

/* Inherit from this class for your domain layer tests. */
public abstract class SamplesDomainTestBase<TStartupModule> : SamplesTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
