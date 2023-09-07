using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.QuestionAggregateConfigurations
{
    public class QuestionEntityTypeConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.ToTable("questions", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.Property(e => e.QuestionContent).IsRequired().HasColumnType("text"); //nvarchar(max)

            // foreign key
            builder.HasOne(x => x.QuestionType).WithMany(x => x.Questions).HasForeignKey(x => x.QuestionTypeId);
            builder.HasOne(x => x.Level).WithMany(x => x.Questions).HasForeignKey(x => x.LevelId);

            builder.HasData(
                new Question
                {
                    Id = "0b8d4bf8-635d-402f-a28a-41b8c344c33d",
                    QuestionContent = "Just think,____2 years' time, we'll be 20 both.",
                    LevelId = "7b70ddba-b8b0-42f8-961e-20785f0f564b",
                    QuestionTypeId = "6f01c413-497a-4745-93d4-4e41d254fdad",
                    UserId = "c4c93c76-e6bf-4608-8e84-dce4a1625fad",
                    ShuffleAnswers = true
                }
            );
        }
    }
}