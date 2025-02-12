using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Tenant.IndependentTablespace.Impl;
using MySqlConnector;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using Microsoft.Data.Sqlite;
using Npgsql;
using Oracle.ManagedDataAccess.Client;
using Volo.Abp.Tenant.IndependentTablespace.HostedService;
using Volo.Abp.Tenant.IndependentTablespace.Impl.Mysql;
using Volo.Abp.Tenant.IndependentTablespace.Impl.SqlServier;
using Volo.Abp.Tenant.IndependentTablespace.Impl.Npgsql;
using Volo.Abp.Tenant.IndependentTablespace.Impl.Oracle;
using Volo.Abp.Tenant.IndependentTablespace.Impl.Sqlite;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public class VoloAbpTenantIndependentTablespaceModule : AbpModule
    {

        public override  Task ConfigureServicesAsync(ServiceConfigurationContext context)
        {
            context.Services.AddScoped<IDbContextBuilder, DbContextBuilder>();

            context.Services.AddSingleton<IDbScriptStore, LocalDbScriptStore>();
            context.Services.AddSingleton<IDbProcessorFactory, DbProcessorFactory>();
            context.Services.AddSingleton<IDbConnectionStringFactory, DbConnectionStringFactory>();

            context.Services.AddKeyedScoped<IDbConnectionModifier, SqlDbConnectionModifier>(DatabaseType.Sql);
            context.Services.AddKeyedScoped<IDbConnectionModifier, MySqlDbConnectionModifier>(DatabaseType.MySql);
            context.Services.AddKeyedScoped<IDbConnectionModifier, SqliteDbConnectionModifier>(DatabaseType.Sqlite);
            context.Services.AddKeyedScoped<IDbConnectionModifier, NpgsqlDbConnectionModifier>(DatabaseType.Npgsql);
            context.Services.AddKeyedScoped<IDbConnectionModifier, OracleDbConnectionModifier>(DatabaseType.Oracle);

            context.Services.AddKeyedScoped<IDbProcessor, SqlDbProcessor>(DatabaseType.Sql);
            context.Services.AddKeyedScoped<IDbProcessor, MySqlDbProcessor>(DatabaseType.MySql);
            context.Services.AddKeyedScoped<IDbProcessor, SqliteDbProcessor>(DatabaseType.Sqlite);
            context.Services.AddKeyedScoped<IDbProcessor, NpgsqlDbProcessor>(DatabaseType.Npgsql);
            context.Services.AddKeyedScoped<IDbProcessor, OracleDbProcessor>(DatabaseType.Oracle);


            return Task.CompletedTask;
        }

        public override Task PostConfigureServicesAsync(ServiceConfigurationContext context)
        {
            context.Services.AddHostedService<DbMigrateHostedService>();
            context.Services.AddHostedService<ScriptGenerationHostedService>();
            return Task.CompletedTask;
        }

       
    }
}
