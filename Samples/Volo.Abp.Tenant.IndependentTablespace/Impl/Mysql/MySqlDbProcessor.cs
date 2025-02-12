
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Mysql
{
    public class MySqlDbProcessor : IDbProcessor
    {
        private readonly IDbScriptStore dbScriptStore;
        private readonly IDbContextBuilder dbContextBuilder;

        public MySqlDbProcessor(IDbScriptStore dbScriptStore, IDbContextBuilder dbContextBuilder)
        {
            this.dbScriptStore = dbScriptStore;
            this.dbContextBuilder = dbContextBuilder;
        }

        const string CreateDatabaseSql = @"SET @DatabaseName = 'database_name';

-- 判断数据库是否存在
SET @sql := CONCAT('SELECT SCHEMA_NAME FROM INFORMATION_SCHEMA.SCHEMATA WHERE SCHEMA_NAME = ""', @DatabaseName, '""');
PREPARE stmt FROM @sql;
EXECUTE stmt;
DEALLOCATE PREPARE stmt;

IF FOUND_ROWS() = 0 THEN
    -- 创建数据库
    SET @sql := CONCAT('CREATE DATABASE ', @DatabaseName);
    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;

    SELECT '数据库创建成功: ' AS message, @DatabaseName AS database_name;
ELSE
    SELECT '数据库已存在: ' AS message, @DatabaseName AS database_name;
END IF;";




        public async Task InitDb(string connectionString)
        {
            await CreateDb(connectionString);
            await ExecuteSqlAsync(connectionString, dbScriptStore.GetSql());
        }



        public async Task CreateDb(string connectionString)
        {
            var masterConnectionString = dbContextBuilder.GetDbContext().Database.GetConnectionString();
            var connection = new MySqlConnection(connectionString);
            var sql = CreateDatabaseSql.Replace("database_name", connection.Database);
            await ExecuteSqlAsync(masterConnectionString, sql);


        }

        public async Task<int> ExecuteSqlAsync(string connectionString, string sql)
        {
            try
            {
                var connection = new MySqlConnection(connectionString);
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
