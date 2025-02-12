using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public class TenantCareateHandlers : ILocalEventHandler<TenantCreatedEto>, ITransientDependency
    {
        private readonly IDbContextBuilder dbContextBuilder;
        private readonly ICurrentTenant currentTenant;
        private readonly IDbProcessorFactory dbProcessor;
        private readonly IDbConnectionStringFactory dbConnectionStringFactory;
        private readonly ITenantAppService tenantAppService;

        public TenantCareateHandlers(IDbContextBuilder dbContextBuilder, 
            ICurrentTenant  currentTenant,
            IDbProcessorFactory dbProcessor,
            IDbConnectionStringFactory dbConnectionStringFactory,
            ITenantAppService tenantAppService)
        {
            this.dbContextBuilder = dbContextBuilder;
            this.currentTenant = currentTenant;
            this.dbProcessor = dbProcessor;
            this.dbConnectionStringFactory = dbConnectionStringFactory;
            this.tenantAppService = tenantAppService;
        }

        public async Task HandleEventAsync(TenantCreatedEto eventData)
        {

            var connection = dbConnectionStringFactory.GetConnectionString(eventData.Id);
            await tenantAppService.UpdateDefaultConnectionStringAsync(eventData.Id, connection);
            await dbProcessor.InitDb(connection);

        }
    }
}
