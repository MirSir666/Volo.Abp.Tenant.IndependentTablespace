using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.SqlServier
{
    public class SqlDbConnectionModifier : DbConnectionModifierBase, IDbConnectionModifier
    {
        public SqlDbConnectionModifier(IOptions<IndependentTablespaceOptions> options) : base(options)
        {
        }

        public override string ModDatabaseName(string dbConnectionString, string database)
        {
            var dbConnection = new SqlConnectionStringBuilder(dbConnectionString);
            database = base.PackageDatabaseName(database);
            dbConnection.InitialCatalog = database;
            return dbConnection.ToString();
        }
    }
}
