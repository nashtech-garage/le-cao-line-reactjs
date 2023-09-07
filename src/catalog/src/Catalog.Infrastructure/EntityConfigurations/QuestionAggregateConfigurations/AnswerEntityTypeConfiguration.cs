using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.QuestionAggregateConfigurations
{
    public class AnswerEntityTypeConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.ToTable("answers", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.Property(e => e.AnswerContent).IsRequired().HasColumnType("text");

            builder.HasOne(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionId);

            builder.HasData(
                new Answer
                {
                    Id = "c765cb93-f518-45ca-8372-0aa288f9d5b3",
                    QuestionId = "0b8d4bf8-635d-402f-a28a-41b8c344c33d",
                    AnswerContent = "under",
                    AnswerValue = "false",
                    AllowShuffle = true,
                    MatchingPosition = 0,
                },
                new Answer
                {
                    Id = "d079864f-2995-4357-8d3f-2784a1bffd23",
                    QuestionId = "0b8d4bf8-635d-402f-a28a-41b8c344c33d",
                    AnswerContent = "in",
                    AnswerValue = "false",
                    AllowShuffle = true,
                    MatchingPosition = 0,
                },
                new Answer
                {
                    Id = "687e87df-d57a-4578-86df-3dc1938bfabb",
                    QuestionId = "0b8d4bf8-635d-402f-a28a-41b8c344c33d",
                    AnswerContent = "after",
                    AnswerValue = "true",
                    AllowShuffle = true,
                    MatchingPosition = 0,
                },
                new Answer
                {
                    Id = "35531282-6772-413c-99a0-57c8a7059c49",
                    QuestionId = "0b8d4bf8-635d-402f-a28a-41b8c344c33d",
                    AnswerContent = "over",
                    AnswerValue = "true",
                    AllowShuffle = true,
                    MatchingPosition = 0,
                }
            );
        }
    }
}