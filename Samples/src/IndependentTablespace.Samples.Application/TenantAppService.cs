using IndependentTablespace.Samples.Departments;
using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.EventBus.Local;
using Volo.Abp.MultiTenancy;
using Volo.Abp.TenantManagement;

namespace IndependentTablespace.Samples
{
    [AllowAnonymous]
    public class MyTenantAppService :TenantAppService, ITenantAppService, ITransientDependency
    {
        public MyTenantAppService(ITenantRepository tenantRepository, ITenantManager tenantManager, IDataSeeder dataSeeder, IDistributedEventBus distributedEventBus, ILocalEventBus localEventBus) : base(tenantRepository, tenantManager, dataSeeder, distributedEventBus, localEventBus)
        {
        }

        public override async Task<TenantDto> GetAsync(Guid id) => await base.GetAsync(id);

        public override async Task<PagedResultDto<TenantDto>> GetListAsync(GetTenantsInput input)=> await base.GetListAsync(input);

        [AllowAnonymous]
        public override async Task<TenantDto> CreateAsync(TenantCreateDto input) => await base.CreateAsync(input);


        public override async Task<TenantDto> UpdateAsync(Guid id, TenantUpdateDto input) => await base.UpdateAsync(id, input);
        


        public override async Task DeleteAsync(Guid id)=>await base.DeleteAsync(id);


        [AllowAnonymous]
        public override async Task<string> GetDefaultConnectionStringAsync(Guid id)=>await base.GetDefaultConnectionStringAsync(id);


        [AllowAnonymous]
        public override async Task UpdateDefaultConnectionStringAsync(Guid id, string defaultConnectionString)=> await base.UpdateDefaultConnectionStringAsync(id, defaultConnectionString);

        [AllowAnonymous]
        public override async Task DeleteDefaultConnectionStringAsync(Guid id) => await base.GetDefaultConnectionStringAsync(id);    
    }
}
