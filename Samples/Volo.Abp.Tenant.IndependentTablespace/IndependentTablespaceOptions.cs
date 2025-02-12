using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.EntityFrameworkCore;

namespace Volo.Abp.Tenant.IndependentTablespace
{
    public class IndependentTablespaceOptions
    {
      

        /// <summary>
        /// 主库上下文类型
        /// </summary>
        public Type MasterDbContextType
        {
            get { return masterDbContextType; }
     
        }
        private Type masterDbContextType;


        public void SetMasterDbContext<TDbContext>() where TDbContext : DbContext, IEfCoreDbContext
          => masterDbContextType = typeof(TDbContext);

        private Type slaveDbContextType;
        /// <summary>
        /// 从库上下文类型
        /// </summary>
        public Type SlaveDbContextType
        {
            get { return slaveDbContextType; }
        }

        public void SetSlaveDbContext<TDbContext>() where TDbContext : DbContext, IEfCoreDbContext
          => slaveDbContextType = typeof(TDbContext);

        /// <summary>
        /// 开头数据库名称
        /// </summary>
        public string? StartDatabaseName { get; set; }

        /// <summary>
        /// 结尾数据库名称
        /// </summary>
        public string? EndDatabaseName { get; set; }

    }
}
