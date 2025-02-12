using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
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
    /// <summary>
    /// 数据结构迁移同步
    /// </summary>
    public class DbMigrateHostedService : IHostedService
    {
        private readonly ITenantRepository tenantRepository;
        private readonly IDbContextBuilder dbContextBuilder;
        private readonly IOptions<IndependentTablespaceOptions> options;
        private readonly ICurrentTenant currentTenant;

        public DbMigrateHostedService(ITenantRepository tenantRepository,
            IDbContextBuilder dbContextBuilder,
            IOptions<IndependentTablespaceOptions> options,
            ICurrentTenant currentTenant)
        {
            this.tenantRepository = tenantRepository;
            this.dbContextBuilder = dbContextBuilder;
            this.options = options;
            this.currentTenant = currentTenant;
        }
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            if (!options.Value.IsMigrateHostedService) return ;
            
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
