using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.EntityConfigurations.QuestionAggregateConfigurations
{
    public class TagEntityTypeConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tags", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);

            builder.Property(e => e.Description).HasColumnType("text");
            builder.HasData(
                new Tag
                {
                    Id = "d1879bda-01dd-43dd-afdd-3e01578e7864",
                    Name = "1",
                    Description = "Khái niệm và quy tắc giao thông đường bộ",
                },
                new Tag
                {
                    Id = "77f517bd-1855-4e0a-ac49-6893a707520c",
                    Name = "2",
                    Description = "Nghiệp vụ vận tải",
                },
                new Tag
                {
                    Id = "7c99c1ee-a1c8-4e1b-a9a4-a174760e6dc2",
                    Name = "3",
                    Description = "Văn hóa giao thông và đạo đức người lái xe",
                },
                new Tag
                {
                    Id = "056d3522-078a-4d46-9262-d56ea7e557ea",
                    Name = "4",
                    Description = "Kỹ thuật lái xe",
                },
                new Tag
                {
                    Id = "f2919aa8-c48b-4311-870f-2ae3c80ac7fe",
                    Name = "5",
                    Description = "Cấu tạo và sửa chữa",
                },
                new Tag
                {
                    Id = "b97ae130-8c1c-42b6-a47c-4e5e1fc056b6",
                    Name = "6",
                    Description = "Hệ thống biển báo hiệu đường bộ",
                },
                new Tag
                {
                    Id = "b523c423-79c9-4d29-82ee-aec0ee4db213",
                    Name = "7",
                    Description = "Các thế sa hình và kỹ năng xử lý tình huống giao thông",
                },
                new Tag
                {
                    Id = "80f521b3-c1d8-42ad-8c04-8e3d93e56fbe",
                    Name = "8",
                    Description = "Các khái niệm",
                },
                new Tag
                {
                    Id = "64f5b16d-5656-4418-8b40-7cb4c972bdd4",
                    Name = "9",
                    Description = "Quy tắc giao thông",
                },
                new Tag
                {
                    Id = "244b45f1-fca2-4c6b-9a1f-71d7e44919c5",
                    Name = "10",
                    Description = "Quy định tốc độ, khoảng cách",
                },
                new Tag
                {
                    Id = "bedbcaa0-fa15-4ee2-89a2-cbab79dd66ca",
                    Name = "11",
                    Description = "Câu hỏi về tình huống mất an toàn giao thông nghiêm trọng (điểm liệt)",
                }
            );
        }
    }
}