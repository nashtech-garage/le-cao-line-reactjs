using Catalog.Domain.AggregatesModel.ExamAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.EntityConfigurations.ExamAggregateConfigurations
{
    public class ExamResultEntityTypeConfiguration : IEntityTypeConfiguration<ExamResult>
    {
        public void Configure(EntityTypeBuilder<ExamResult> builder)
        {
            builder.ToTable("examResults", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.Exam).WithMany(x => x.ExamResults).HasForeignKey(x => x.ExamId);
        }
    }
}
