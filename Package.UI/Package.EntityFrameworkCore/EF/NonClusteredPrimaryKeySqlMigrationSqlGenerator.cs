using Microsoft.EntityFrameworkCore.Migrations;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace Package.EntityFrameworkCore.EF
{
    public class NonClusteredPrimaryKeySqlMigrationSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public override IEnumerable<System.Data.Entity.Migrations.Sql.MigrationStatement> Generate(IEnumerable<MigrationOperation> migrationOperations, string providerManifestToken)
        {
            var primaries = migrationOperations.OfType<CreateTableOperation>().Where(x => x.PrimaryKey.IsClustered).Select(x => x.PrimaryKey).ToList();
            var indexes = migrationOperations.OfType<CreateIndexOperation>().Where(x => x.IsClustered).ToList();
            foreach (var index in indexes)
            {
                var primary = primaries.Where(x => x.Table == index.Table).SingleOrDefault();
                if (primary != null)
                {
                    primary.IsClustered = false;
                }
            }
            return base.Generate(migrationOperations, providerManifestToken);
        }
    }
}
