using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace IndependentTablespace.Samples.Data;

/* This is used if database provider does't define
 * ISamplesDbSchemaMigrator implementation.
 */
public class NullSamplesDbSchemaMigrator : ISamplesDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
