using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.SqlServier
{
    public class SqlDbProcessor : IDbProcessor
    {

        private readonly IDbScriptStore dbScriptStore;
        private readonly IDbContextBuilder dbContextBuilder;

        public SqlDbProcessor(IDbScriptStore dbScriptStore, IDbContextBuilder dbContextBuilder)
        {
            this.dbScriptStore = dbScriptStore;
            this.dbContextBuilder = dbContextBuilder;
        }

        const string CreateDatabaseSql = @"DECLARE @DatabaseName NVARCHAR(400)
SET @DatabaseName = 'database_name'

-- 判断数据库是否存在
IF NOT EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = @DatabaseName)
BEGIN
    -- 创建数据库
    EXEC ('CREATE DATABASE ' + @DatabaseName)
    PRINT '数据库创建成功: ' + @DatabaseName
END
ELSE
BEGIN
    PRINT '数据库已存在: ' + @DatabaseName
END";




        public async Task InitDb(string connectionString)
        {
            await CreateDb(connectionString);
            await ExecuteSqlAsync(connectionString, dbScriptStore.GetSql());
        }



        public async Task CreateDb(string connectionString)
        {
            var masterConnectionString = dbContextBuilder.GetDbContext().Database.GetConnectionString() ?? string.Empty;
            var connection = new SqlConnection(connectionString);
            var sql = CreateDatabaseSql.Replace("database_name", connection.Database);
            await ExecuteSqlAsync(masterConnectionString, sql);


        }

        public async Task<int> ExecuteSqlAsync(string connectionString, string sql)
        {
            try
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                var comm = connection.CreateCommand();
                comm.CommandText = sql;
                comm.CommandType = CommandType.Text;
                var retint = await comm.ExecuteNonQueryAsync();
                await connection.CloseAsync();
                return retint;
            }
            catch (Exception ex)
            {

                return 0;
            }

        }

    }
}
