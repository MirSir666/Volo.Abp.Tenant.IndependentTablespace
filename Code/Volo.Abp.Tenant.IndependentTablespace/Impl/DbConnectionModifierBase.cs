using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volo.Abp.Tenant.IndependentTablespace.Impl
{
    public abstract class DbConnectionModifierBase : IDbConnectionModifier
    {

        private readonly IOptions<IndependentTablespaceOptions> options;

        public DbConnectionModifierBase(IOptions<IndependentTablespaceOptions> options)
        {
            this.options = options;
        }

        public abstract string ModDatabaseName(string dbConnectionString, string database);


        public  virtual string PackageDatabaseName(string database)
        {
            var startDatabaseName = options.Value.StartDatabaseName;
            if (!string.IsNullOrEmpty(startDatabaseName))
                database = startDatabaseName + database;

            var endDatabaseName = options.Value.EndDatabaseName;
            if (!string.IsNullOrEmpty(endDatabaseName))
                database = database + endDatabaseName;

            return database;

        }

    }
}
