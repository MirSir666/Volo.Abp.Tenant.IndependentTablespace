
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Sqlite
{
    public class SqliteDbConnectionModifier : DbConnectionModifierBase, IDbConnectionModifier
    {
        public SqliteDbConnectionModifier(IOptions<IndependentTablespaceOptions> options) : base(options)
        {
        }

        public override string ModDatabaseName(string dbConnectionString, string database)
        {
            var dbConnection = new SqliteConnectionStringBuilder(dbConnectionString);
            database = base.PackageDatabaseName(database);
            dbConnection.DataSource = database + ".db";
            return dbConnection.ToString();
        }
    }
}
