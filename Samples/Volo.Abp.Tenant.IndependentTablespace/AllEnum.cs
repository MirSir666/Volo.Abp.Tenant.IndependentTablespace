using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public enum DbContextType
    {
        Master,
        Slave
    }


    public enum DatabaseType
    {
        Other = 0,
        Sqlite = 1,
        Sql = 2,
        Npgsql = 3,
        MySql = 4,
        Oracle=5
    }
}
