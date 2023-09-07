using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Migrations.Internal;

namespace Catalog.Infrastructure.Repositories
{
    public class CustomNpgsqlHistoryRepository : NpgsqlHistoryRepository
    {
        public CustomNpgsqlHistoryRepository(HistoryRepositoryDependencies dependencies)
            : base(dependencies)
        {
        }

        protected override void ConfigureTable(EntityTypeBuilder<HistoryRow> history)
        {
            base.ConfigureTable(history);
            history.Property(h => h.MigrationId).HasColumnName("MigrationId").HasMaxLength(150);
            history.Property(h => h.ProductVersion).HasColumnName("ProductVersion").HasMaxLength(32);
        }
    }
}