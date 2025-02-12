using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl
{
    /// <summary>
    /// 脚本存储
    /// </summary>
    public class LocalDbScriptStore : IDbScriptStore
    {
        private static string Sql;
        public string GetSql() => Sql;

        public void SetSql(string sql) => Sql = sql;


    }
}
