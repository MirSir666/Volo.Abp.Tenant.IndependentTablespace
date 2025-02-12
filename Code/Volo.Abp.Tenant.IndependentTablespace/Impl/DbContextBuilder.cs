using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl
{
    public class DbContextBuilder : IDbContextBuilder
    {
        private readonly IAbpLazyServiceProvider abpLazyServiceProvider;
        private readonly IOptions<IndependentTablespaceOptions> options;

        public DbContextBuilder(IAbpLazyServiceProvider abpLazyServiceProvider,
            IOptions<IndependentTablespaceOptions> options)
        {
            this.abpLazyServiceProvider = abpLazyServiceProvider;
            this.options = options;
        }

        public IAbpEfCoreDbContext GetDbContext(DbContextType type = DbContextType.Master)
        {
            IAbpEfCoreDbContext dbContext = null;

            dbContext = (IAbpEfCoreDbContext)abpLazyServiceProvider.GetService(type == DbContextType.Master ?
                options.Value.MasterDbContextType
                : options.Value.SlaveDbContextType,
                dbContext);
            return dbContext;

        }


       
    }
}
