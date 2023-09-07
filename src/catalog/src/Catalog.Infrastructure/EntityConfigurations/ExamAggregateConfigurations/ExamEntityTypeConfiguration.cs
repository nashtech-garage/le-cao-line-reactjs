using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.Constants;

namespace Catalog.Infrastructure.EntityConfigurations.ExamAggregateConfigurations
{
    public class ExamEntityTypeConfiguration : IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("exams", CatalogContext.DEFAULT_SCHEMA);
            builder.HasKey(o => o.Id);
            builder.HasData(
                new Exam
                {
                    Id = FixedExam.A1Id,
                    Code = FixedExam.A1Id,
                    Name = "Level A1 Driving Test",
                    Description = "Level A1 Driving Test",
                    DefaultQuestionNumber = 25,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.A1Id)
                },
                new Exam
                {
                    Id = FixedExam.A2Id,
                    Code = FixedExam.A2Id,
                    Name = "Level A2 Driving Test",
                    Description = "Level A2 Driving Test",
                    DefaultQuestionNumber = 25,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.A2Id)
                },
                new Exam
                {
                    Id = FixedExam.A3Id,
                    Code = FixedExam.A3Id,
                    Name = "Level A3 Driving Test",
                    Description = "Level A3 Driving Test",
                    DefaultQuestionNumber = 25,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.A3Id)
                },
                new Exam
                {
                    Id = FixedExam.A4Id,
                    Code = FixedExam.A4Id,
                    Name = "Level A4 Driving Test",
                    Description = "Level A4 Driving Test",
                    DefaultQuestionNumber = 25,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.A4Id)
                },
                new Exam
                {
                    Id = FixedExam.B1Id,
                    Code = FixedExam.B1Id,
                    Name = "Level B1 Driving Test",
                    Description = "Level B1 Driving Test",
                    DefaultQuestionNumber = 30,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.B1Id)
                },
                new Exam
                {
                    Id = FixedExam.B2Id,
                    Code = FixedExam.B2Id,
                    Name = "Level B2 Driving Test",
                    Description = "Level B2 Driving Test",
                    DefaultQuestionNumber = 35,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.B2Id)
                },
                new Exam
                {
                    Id = FixedExam.CId,
                    Code = FixedExam.CId,
                    Name = "Level C Driving Test",
                    Description = "Level C Driving Test",
                    DefaultQuestionNumber = 40,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.CId)
                },
                new Exam
                {
                    Id = FixedExam.DId,
                    Code = FixedExam.DId,
                    Name = "Level D Driving Test",
                    Description = "Level D Driving Test",
                    DefaultQuestionNumber = 45,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.DId)
                },
                new Exam
                {
                    Id = FixedExam.EId,
                    Code = FixedExam.EId,
                    Name = "Level E Driving Test",
                    Description = "Level E Driving Test",
                    DefaultQuestionNumber = 45,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.EId)
                },
                new Exam
                {
                    Id = FixedExam.FId,
                    Code = FixedExam.FId,
                    Name = "Level F Driving Test",
                    Description = "Level F Driving Test",
                    DefaultQuestionNumber = 45,
                    PercentageToPass = ExamGetValue.GetPercent(FixedExam.FId)
                }
                ); ;
        }
    }
}
