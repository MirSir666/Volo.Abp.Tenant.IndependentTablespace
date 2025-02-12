using IndependentTablespace.Samples.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Volo.Abp.AspNetCore.Mvc.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Autofac;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;
using IndependentTablespace.Samples.Localization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Tenant.IndependentTablespace;

namespace IndependentTablespace.Samples.HttpApi.Host
{
    [DependsOn(
    typeof(SamplesHttpApiModule),
    typeof(SamplesApplicationModule),
    typeof(SamplesEntityFrameworkCoreModule),
    typeof(AbpAutofacModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(VoloAbpTenantIndependentTablespaceModule),
    typeof(AbpSwashbuckleModule)
    )]

    public class IndependentTablespaceSamplesApiHostModule : AbpModule
    {
        public override void PreConfigureServices(ServiceConfigurationContext context)
        {
            LimitedResultRequestDto.MaxMaxResultCount = 200000;

            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            context.Services.PreConfigure<AbpMvcDataAnnotationsLocalizationOptions>(options =>
            {
                options.AddAssemblyResource(
                    typeof(SamplesResource),
                    typeof(SamplesDomainModule).Assembly,
                    typeof(SamplesDomainSharedModule).Assembly,
                    typeof(SamplesApplicationModule).Assembly,
                    typeof(SamplesApplicationContractsModule).Assembly
                );
            });

            
        }

        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var hostingEnvironment = context.Services.GetHostingEnvironment();
            var configuration = context.Services.GetConfiguration();

            ConfigureAuthentication(context);
            ConfigureUrls(configuration);
            ConfigureAutoMapper();
            ConfigureVirtualFileSystem(hostingEnvironment);
            ConfigureAutoApiControllers();
            ConfigureSwaggerServices(context.Services);
        }

        private void ConfigureAuthentication(ServiceConfigurationContext context)
        {
           
        }

        private void ConfigureUrls(IConfiguration configuration)
        {
           
        }


        private void ConfigureAutoMapper()
        {
            Configure<AbpAutoMapperOptions>(options =>
            {
            });
        }

        private void ConfigureVirtualFileSystem(IWebHostEnvironment hostingEnvironment)
        {
            
        }


        private void ConfigureAutoApiControllers()
        {
            Configure<AbpAspNetCoreMvcOptions>(options =>
            {
                options.ConventionalControllers.Create(typeof(SamplesApplicationModule).Assembly);
            });
        }

        private void ConfigureSwaggerServices(IServiceCollection services)
        {
            services.AddAuthentication();
            services.AddAbpSwaggerGen(
                options =>
                {
                    var xmlFile = $"IndependentTablespace.Samples.Application.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                    options.IncludeXmlComments(xmlPath);
                    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Samples API", Version = "v1" });
                    options.DocInclusionPredicate((docName, description) => true);
                    options.CustomSchemaIds(type => type.FullName);
                }
            );
        }

        public override void OnApplicationInitialization(ApplicationInitializationContext context)
        {
            var app = context.GetApplicationBuilder();
            var env = context.GetEnvironment();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAbpRequestLocalization();

            app.UseCorrelationId();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();

            app.UseUnitOfWork();
            app.UseDynamicClaims();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseAbpSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Samples API");
            });

            app.UseAuditing();
            app.UseAbpSerilogEnrichers();
            app.UseConfiguredEndpoints();
        }
    }
}
