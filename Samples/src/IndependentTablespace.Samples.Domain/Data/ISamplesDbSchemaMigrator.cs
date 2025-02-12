using System.Threading.Tasks;

namespace IndependentTablespace.Samples.Data;

public interface ISamplesDbSchemaMigrator
{
    Task MigrateAsync();
}
