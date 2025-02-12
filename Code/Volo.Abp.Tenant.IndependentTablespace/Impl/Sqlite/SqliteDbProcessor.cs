
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl.Sqlite
{
    public class SqliteDbProcessor : IDbProcessor
    {
        private readonly IDbScriptStore dbScriptStore;
        private readonly IDbContextBuilder dbContextBuilder;

        public SqliteDbProcessor(IDbScriptStore dbScriptStore, IDbContextBuilder dbContextBuilder)
        {
            this.dbScriptStore = dbScriptStore;
            this.dbContextBuilder = dbContextBuilder;
        }


        public async Task InitDb(string connectionString)
        {
            await CreateDb(connectionString);
            await ExecuteSqlAsync(connectionString, dbScriptStore.GetSql());
        }



        public  Task CreateDb(string connectionString)
        {
            var connection = new SQLiteConnection(connectionString);
            // 数据库文件名
            string databaseFile = connection.Database;

            // 检查数据库文件是否存在
            if (!File.Exists(databaseFile))
                SQLiteConnection.CreateFile(databaseFile); // 创建数据库文件

            return Task.CompletedTask;
        }

        public async Task<int> ExecuteSqlAsync(string connectionString, string sql)
        {
            try
            {
                var connection = new SQLiteConnection(connectionString);
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
