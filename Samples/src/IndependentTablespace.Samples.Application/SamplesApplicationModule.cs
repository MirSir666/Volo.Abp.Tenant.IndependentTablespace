using IndependentTablespace.Samples.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Tenant.IndependentTablespace;
using Volo.Abp.TenantManagement;

namespace IndependentTablespace.Samples;

[DependsOn(
    typeof(SamplesDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(SamplesApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule)
    )]
public class SamplesApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<SamplesApplicationModule>();
        });
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });

        this.Configure<IndependentTablespaceOptions>(o => {
            o.SetMasterDbContext<SamplesDbContext>(); //设置主库DbContext
            // o.SetSlaveDbContext<SamplesDbContext>();
            // o.EndDatabaseName = "store"; //数据库名结尾
            // o.StartDatabaseName="store"; //数据库名开头
            // o.IsMigrateHostedService = true; //是否启用自动同步表结构任务(默认:true)
        });
        context.Services.AddTransient<ITenantStore , MyTenantStore> ();
        context.Services.AddScoped<ITenantAppService, MyTenantAppService>();
    }
}
