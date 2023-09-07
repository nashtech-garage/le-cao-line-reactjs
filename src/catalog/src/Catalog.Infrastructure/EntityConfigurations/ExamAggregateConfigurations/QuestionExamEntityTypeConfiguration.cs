using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.ExamAggregateConfigurations
{
    public class QuestionExamEntityTypeConfiguration : IEntityTypeConfiguration<QuestionExam>
    {
        public void Configure(EntityTypeBuilder<QuestionExam> builder)
        {
            builder.ToTable("exam_questions", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            // foreign key
            builder.HasOne(x => x.Question).WithMany(x => x.QuestionExams).HasForeignKey(x => x.QuestionId);
            builder.HasOne(x => x.Exam).WithMany(x => x.QuestionExams).HasForeignKey(x => x.ExamId);
        }
    }
}