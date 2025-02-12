using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using IndependentTablespace.Samples.Data;
using Volo.Abp.DependencyInjection;

namespace IndependentTablespace.Samples.EntityFrameworkCore;

public class EntityFrameworkCoreSamplesDbSchemaMigrator
    : ISamplesDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreSamplesDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the SamplesDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<SamplesDbContext>()
            .Database
            .MigrateAsync();
    }
}
