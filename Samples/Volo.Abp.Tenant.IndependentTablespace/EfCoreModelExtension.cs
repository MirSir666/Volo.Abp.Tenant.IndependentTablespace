using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Volo.Abp.EntityFrameworkCore;
using System.Data.Common;
using Volo.Abp.Tenant.IndependentTablespace.Impl;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public static class EfCoreModelExtension
    {

        public static DatabaseType GetDatabaseType(this IAbpEfCoreDbContext dbContext)
        {
            using (var dbConnection = dbContext.Database.GetDbConnection()) 
            return dbConnection.GetDatabaseType();
        }

        public static string GenerateCreateScript(this IAbpEfCoreDbContext dbContext)
        {

            var database = dbContext.Database;
            var migrator = database.GetService<IMigrator>();

            if (migrator == null)
            {
                var databaseProvider = database.GetService<IDatabaseProvider>();
                throw new Exception("Unknown");
            }

            return migrator.GenerateScript(null, null, MigrationsSqlGenerationOptions.NoTransactions);
        }
    }
}
