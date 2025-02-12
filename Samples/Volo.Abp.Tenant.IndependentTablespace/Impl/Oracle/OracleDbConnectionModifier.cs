
using Microsoft.Extensions.Options;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Oracle
{
    public class OracleDbConnectionModifier : DbConnectionModifierBase, IDbConnectionModifier
    {
        public OracleDbConnectionModifier(IOptions<IndependentTablespaceOptions> options) : base(options)
        {
        }

        public override string ModDatabaseName(string dbConnectionString, string database)
        {
            var dbConnection = new OracleConnectionStringBuilder(dbConnectionString);
            database = base.PackageDatabaseName(database);
            dbConnection.DataSource = database;
            return dbConnection.ToString();
        }
    }
}
