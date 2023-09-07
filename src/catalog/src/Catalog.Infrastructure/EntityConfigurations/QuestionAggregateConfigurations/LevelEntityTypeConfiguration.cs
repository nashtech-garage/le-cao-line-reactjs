using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.QuestionAggregateConfigurations
{
    public class LevelEntityTypeConfiguration : IEntityTypeConfiguration<Level>
    {
        public void Configure(EntityTypeBuilder<Level> builder)
        {
            builder.ToTable("levels", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.Property(e => e.Description).HasColumnType("text");
            builder.HasData(
                new Level
                {
                    Id = "7b70ddba-b8b0-42f8-961e-20785f0f564b",
                    Name = "Knowledge",
                    Description = "Knowledge",
                },
                new Level
                {
                    Id = "abdbeff3-9840-4200-a8c6-e1f1e3d0c428",
                    Name = "Comprehension",
                    Description = "Comprehension",
                },
                new Level
                {
                    Id = "c363cdf9-cadb-4090-a03d-43c4f5303e9b",
                    Name = "Application",
                    Description = "Application",
                },
                new Level
                {
                    Id = "0293d928-8ec7-4bf7-82cf-894235220294",
                    Name = "Analysis",
                    Description = "Analysis",
                },
                new Level
                {
                    Id = "d3dd9e4d-0170-45ce-9ee2-78b9f8770e38",
                    Name = "Synthesis",
                    Description = "Synthesis",
                },
                new Level
                {
                    Id = "999abd49-0b6d-4fd0-81f4-0a419b71bac8",
                    Name = "Evaluation",
                    Description = "Evaluation",
                }
            );
        }
    }
}