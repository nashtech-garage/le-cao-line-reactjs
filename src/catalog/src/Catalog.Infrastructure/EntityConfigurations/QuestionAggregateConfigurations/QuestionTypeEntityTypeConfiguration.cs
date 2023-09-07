using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.QuestionAggregateConfigurations
{
    public class QuestionTypeEntityTypeConfiguration : IEntityTypeConfiguration<QuestionType>
    {
        public void Configure(EntityTypeBuilder<QuestionType> builder)
        {
            builder.ToTable("questionTypes", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.HasData(
                new QuestionType
                {
                    Id = "6f01c413-497a-4745-93d4-4e41d254fdad",
                    Name = "MCQ",
                    Description = "Multiple Choice Question"
                },
                new QuestionType
                {
                    Id = "42fe49d6-44f9-4006-af32-88f20c315023",
                    Name = "FIB",
                    Description = "Fill In Blanks"
                },
                new QuestionType
                {
                    Id = "33ae4edc-9bc7-4201-afda-28d5cfa4e84e",
                    Name = "MTF",
                    Description = "Match The Following"
                },
                new QuestionType
                {
                    Id = "01fd1f9c-78c4-41b1-a379-1229eba16808",
                    Name = "ORD",
                    Description = "Ordering Sequence"
                }
            );
        }
    }
}