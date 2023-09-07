using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.QuestionAggregateConfigurations
{
    public class TagQuestionEntityTypeConfiguration : IEntityTypeConfiguration<TagQuestion>
    {
        public void Configure(EntityTypeBuilder<TagQuestion> builder)
        {
            builder.ToTable("tag_questions", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            // foreign key
            builder.HasOne(x => x.Question).WithMany(x => x.TagQuestions).HasForeignKey(x => x.QuestionId);
            builder.HasOne(x => x.Tag).WithMany(x => x.TagQuestions).HasForeignKey(x => x.TagId);
        }
    }
}