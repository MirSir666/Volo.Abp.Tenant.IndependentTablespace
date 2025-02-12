using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Npgsql
{
    public class NpgsqlDbProcessor : IDbProcessor
    {
        private readonly IDbScriptStore dbScriptStore;
        private readonly IDbContextBuilder dbContextBuilder;

        public NpgsqlDbProcessor(IDbScriptStore dbScriptStore, IDbContextBuilder dbContextBuilder)
        {
            this.dbScriptStore = dbScriptStore;
            this.dbContextBuilder = dbContextBuilder;
        }

        const string CreateDatabaseSql = @"DO
$$
BEGIN
    -- 判断数据库是否存在
    IF NOT EXISTS (SELECT FROM pg_database WHERE datname = 'database_name') THEN
        -- 创建数据库
        PERFORM dblink_exec('dbname=postgres', 'CREATE DATABASE database_name');
        RAISE NOTICE '数据库创建成功: database_name';
    ELSE
        RAISE NOTICE '数据库已存在: database_name';
    END IF;
END
$$;";




        public async Task InitDb(string connectionString)
        {
            await CreateDb(connectionString);
            await ExecuteSqlAsync(connectionString, dbScriptStore.GetSql());
        }



        public async Task CreateDb(string connectionString)
        {
            var masterConnectionString = dbContextBuilder.GetDbContext().Database.GetConnectionString()?? string.Empty;
            var connection = new NpgsqlConnection(connectionString);
            var sql = CreateDatabaseSql.Replace("database_name", connection.Database);
            await ExecuteSqlAsync(masterConnectionString, sql);


        }

        public async Task<int> ExecuteSqlAsync(string connectionString, string sql)
        {
            try
            {
                var connection = new NpgsqlConnection(connectionString);
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
