using Microsoft.EntityFrameworkCore;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Oracle
{
    public class OracleDbProcessor : IDbProcessor
    {
        private readonly IDbScriptStore dbScriptStore;
        private readonly IDbContextBuilder dbContextBuilder;

        public OracleDbProcessor(IDbScriptStore dbScriptStore, IDbContextBuilder dbContextBuilder)
        {
            this.dbScriptStore = dbScriptStore;
            this.dbContextBuilder = dbContextBuilder;
        }

        const string CreateDatabaseSql = @"DECLARE
    v_count INTEGER := 0;
BEGIN
    -- 判断数据库是否存在
    SELECT COUNT(*) INTO v_count FROM dba_users WHERE username = 'database_name';

    IF v_count = 0 THEN
        -- 创建用户和表空间
        EXECUTE IMMEDIATE 'CREATE USER database_name IDENTIFIED BY your_password 
                           DEFAULT TABLESPACE users 
                           TEMPORARY TABLESPACE temp 
                           QUOTA UNLIMITED ON users';
        EXECUTE IMMEDIATE 'GRANT CONNECT, RESOURCE TO database_name';
        DBMS_OUTPUT.PUT_LINE('数据库用户创建成功: database_name');
    ELSE
        DBMS_OUTPUT.PUT_LINE('数据库用户已存在: database_name');
    END IF;
END;";




        public async Task InitDb(string connectionString)
        {
            await CreateDb(connectionString);
            await ExecuteSqlAsync(connectionString, dbScriptStore.GetSql());
        }



        public async Task CreateDb(string connectionString)
        {
            var masterConnectionString = dbContextBuilder.GetDbContext().Database.GetConnectionString() ?? string.Empty;
            var connection = new OracleConnection(connectionString);
            var sql = CreateDatabaseSql.Replace("database_name", connection.Database);
            await ExecuteSqlAsync(masterConnectionString, sql);


        }

        public async Task<int> ExecuteSqlAsync(string connectionString, string sql)
        {
            try
            {
                var connection = new OracleConnection(connectionString);
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
