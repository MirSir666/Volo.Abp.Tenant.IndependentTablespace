using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public interface IDbConnectionModifier
    {
        string ModDatabaseName(string dbConnectionString,string database);
    }
}
