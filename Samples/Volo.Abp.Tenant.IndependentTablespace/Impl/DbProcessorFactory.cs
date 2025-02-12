using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl
{
    public class DbProcessorFactory: IDbProcessorFactory
    {
        private readonly IDbContextBuilder dbContextBuilder;
        private readonly IAbpLazyServiceProvider abpLazyServiceProvider;

        public DbProcessorFactory(IDbContextBuilder dbContextBuilder, IAbpLazyServiceProvider abpLazyServiceProvider)
        {
            this.dbContextBuilder = dbContextBuilder;
            this.abpLazyServiceProvider = abpLazyServiceProvider;
        }

        public async Task InitDb(string connectionString)
        {

            var dbcontext = dbContextBuilder.GetDbContext();
            var dbConnection = dbcontext.Database.GetDbConnection();
            var type = dbConnection.GetDatabaseType();
            var dbProcessor  = abpLazyServiceProvider.GetKeyedService<IDbProcessor>(type);
            await dbProcessor.InitDb(connectionString);

        }
    }
}
