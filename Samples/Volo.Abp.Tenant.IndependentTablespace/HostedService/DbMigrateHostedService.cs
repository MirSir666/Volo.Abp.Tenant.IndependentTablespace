using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Tenant.IndependentTablespace.Impl;
using Volo.Abp.TenantManagement;

namespace Volo.Abp.Tenant.IndependentTablespace.HostedService
{
    public class DbMigrateHostedService : IHostedService
    {
        private readonly ITenantRepository tenantRepository;
        private readonly IDbContextBuilder dbContextBuilder;
        private readonly ICurrentTenant currentTenant;

        public DbMigrateHostedService(ITenantRepository tenantRepository,
            IDbContextBuilder dbContextBuilder,
            ICurrentTenant currentTenant)
        {
            this.tenantRepository = tenantRepository;
            this.dbContextBuilder = dbContextBuilder;
            this.currentTenant = currentTenant;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            var tenants = await tenantRepository.GetListAsync();
            foreach (var tenant in tenants)
            {
                using (currentTenant.Change(tenant.Id))
                {
                    var dbTenant = dbContextBuilder.GetDbContext();
                    await dbTenant.Database.MigrateAsync();
                }
            }

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
