using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public class DbConnectionStringFactory : IDbConnectionStringFactory
    {
        private readonly IDbContextBuilder dbContextBuilder;
        private readonly IAbpLazyServiceProvider abpLazyServiceProvider;

        public DbConnectionStringFactory(IDbContextBuilder dbContextBuilder, IAbpLazyServiceProvider abpLazyServiceProvider)
        {
            this.dbContextBuilder = dbContextBuilder;
            this.abpLazyServiceProvider = abpLazyServiceProvider;
        }

        public string GetConnectionString(Guid tenantId )
        {

            var dbcontext = dbContextBuilder.GetDbContext();
            var connectionString = dbcontext.Database.GetConnectionString() ?? string.Empty;
            var type = dbcontext.GetDatabaseType();
            var dbConnectionModifier = abpLazyServiceProvider.GetKeyedService<IDbConnectionModifier>(type);
            if (dbConnectionModifier == null)
                throw new System.NotImplementedException();

            var dbconnectionSql = dbConnectionModifier.ModDatabaseName(connectionString, tenantId.ToString("N"));

            return dbconnectionSql;

        }
    }
}
