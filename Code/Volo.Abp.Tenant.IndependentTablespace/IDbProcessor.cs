using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public interface IDbProcessor
    {
        Task CreateDb(string connectionString);

        Task<int> ExecuteSqlAsync(string connectionString,string sql);

        Task InitDb(string connectionString);
    }
}
