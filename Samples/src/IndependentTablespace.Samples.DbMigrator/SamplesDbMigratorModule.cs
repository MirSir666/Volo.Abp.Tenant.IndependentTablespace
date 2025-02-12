using IndependentTablespace.Samples.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace IndependentTablespace.Samples.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SamplesEntityFrameworkCoreModule),
    typeof(SamplesApplicationContractsModule)
    )]
public class SamplesDbMigratorModule : AbpModule
{
}
