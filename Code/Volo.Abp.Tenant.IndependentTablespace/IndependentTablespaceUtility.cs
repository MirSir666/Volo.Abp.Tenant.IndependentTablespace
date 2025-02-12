using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public static class IndependentTablespaceUtility
    {
        public static DatabaseType GetDatabaseType(this DbConnection connection)
        {
            return connection.GetType().Name switch
            {
                "SqlConnection" => DatabaseType.Sql,
                "NpgsqlConnection" => DatabaseType.Npgsql,
                "MySqlConnection" => DatabaseType.MySql,
                "OracleConnection" => DatabaseType.Oracle,
                "SqliteConnection" => DatabaseType.Sqlite,
                _ => DatabaseType.Other
            };
        }
    }



}
