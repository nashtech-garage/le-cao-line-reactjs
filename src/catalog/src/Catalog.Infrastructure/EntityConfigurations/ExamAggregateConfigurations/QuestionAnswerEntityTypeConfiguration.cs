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
    public class QuestionAnswerEntityTypeConfiguration : IEntityTypeConfiguration<QuestionAnswer>
    {
        public void Configure(EntityTypeBuilder<QuestionAnswer> builder)
        {
            builder.ToTable("questionAnswers", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.HasOne(x => x.ExamResult).WithMany(x => x.QuestionAnswers).HasForeignKey(x => x.ExamResultId);
        }
    }
}
