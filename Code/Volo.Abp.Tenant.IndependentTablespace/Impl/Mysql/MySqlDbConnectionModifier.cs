using Microsoft.Extensions.Options;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Mysql
{
    public class MySqlDbConnectionModifier : DbConnectionModifierBase, IDbConnectionModifier
    {
        public MySqlDbConnectionModifier(IOptions<IndependentTablespaceOptions> options) : base(options)
        {
        }

        public override string ModDatabaseName(string dbConnectionString, string database)
        {
            var dbConnection = new MySqlConnectionStringBuilder(dbConnectionString);
            database = base.PackageDatabaseName(database);
            dbConnection.Database = database;
            return dbConnection.ToString();
        }
    }
}
