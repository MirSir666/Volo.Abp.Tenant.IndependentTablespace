using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.MultiTenancy;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Volo.Abp.Tenant.IndependentTablespace.HostedService
{
    /// <summary>
    /// 数据库脚本创建存储
    /// </summary>
    public class ScriptGenerationHostedService : IHostedService
    {
        private readonly IDbContextBuilder dbContextBuilder;
        private readonly IDbScriptStore dbScriptStore;

        public ScriptGenerationHostedService(
            IDbContextBuilder dbContextBuilder,
            IDbScriptStore dbScriptStore)
        {

            this.dbContextBuilder = dbContextBuilder;
            this.dbScriptStore = dbScriptStore;


        }
        public  Task StartAsync(CancellationToken cancellationToken)
        {

            var dbcontext = dbContextBuilder.GetDbContext();
            var sql = dbcontext.GenerateCreateScript();
            dbScriptStore.SetSql(sql);
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
