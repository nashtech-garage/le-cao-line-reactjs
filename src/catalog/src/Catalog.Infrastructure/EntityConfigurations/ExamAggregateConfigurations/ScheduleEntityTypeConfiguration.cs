using Catalog.Domain.AggregatesModel.ExamAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.ExamAggregateConfigurations
{
    public class ScheduleEntityTypeConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.ToTable("schedules", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.Exam).WithMany(x => x.Schedules).HasForeignKey(x => x.ExamId);
        }
    }
}