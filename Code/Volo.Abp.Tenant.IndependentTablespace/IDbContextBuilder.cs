using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;
using static Volo.Abp.Tenant.IndependentTablespace.Impl.DbContextBuilder;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public interface IDbContextBuilder
    {
        IAbpEfCoreDbContext GetDbContext(DbContextType type = DbContextType.Master);
    }
}
