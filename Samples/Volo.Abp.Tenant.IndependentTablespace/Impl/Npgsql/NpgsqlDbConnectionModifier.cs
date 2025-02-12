using Microsoft.Extensions.Options;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Npgsql
{
    public class NpgsqlDbConnectionModifier : DbConnectionModifierBase, IDbConnectionModifier
    {
        public NpgsqlDbConnectionModifier(IOptions<IndependentTablespaceOptions> options) : base(options)
        {
        }

        public override string ModDatabaseName(string dbConnectionString, string database)
        {
            var dbConnection = new NpgsqlConnectionStringBuilder(dbConnectionString);
            database = base.PackageDatabaseName(database);
            dbConnection.Database = database;
            return dbConnection.ToString();
        }
    }
}
