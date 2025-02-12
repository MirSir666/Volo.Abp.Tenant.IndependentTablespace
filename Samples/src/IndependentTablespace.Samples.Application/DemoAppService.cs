using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.TenantManagement;

namespace IndependentTablespace.Samples
{
    [AllowAnonymous]
    [Route("api/[Controller]")]
    public class DemoAppService : ApplicationService
    {
        private readonly ITenantAppService tenantAppService;

        public DemoAppService(ITenantAppService tenantAppService)
        {
            this.tenantAppService = tenantAppService;
        }
        [HttpGet]
        public async Task<string> GetHello()
        {
          
            try
            {

                var guid= Guid.NewGuid().ToString("N");

                var ret = await tenantAppService.CreateAsync(new TenantCreateDto() { AdminEmailAddress = $"{guid}@qq.com", AdminPassword = "123123", Name = guid });
            }
            catch (Exception ex)
            {

                
            }
            return "t";
        }
    }
}
