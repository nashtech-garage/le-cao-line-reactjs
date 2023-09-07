using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Microsoft.Extensions.Logging;

namespace Catalog.Infrastructure
{
    public class CatalogContextSeed
    {
        //public static async Task SeedAsync(CatalogContext catalogContext, ILogger<CatalogContextSeed> logger)
        //{
        //    if (!catalogContext.QuestionTypes.Any()
        //        && !catalogContext.Questions.Any()
        //        && !catalogContext.Answers.Any())
        //    {
        //        await SeedSingleChoiceQuestion(catalogContext);
        //        await SeedMultipleChoiceQuestion(catalogContext);
        //    }

        //    logger.LogInformation("Seed database associated with context {DbContextName}", typeof(CatalogContext).Name);

        //}

        //private static async Task SeedSingleChoiceQuestion(CatalogContext catalogContext)
        //{
        //    var questionType = new QuestionType() { Name = "SingleChoice" };
        //    catalogContext.QuestionTypes.Add(questionType);
        //    await catalogContext.SaveChangesAsync();

        //    var question = new Question()
        //    {
        //        QuestionContent = "Just think,____2 years' time, we'll be 20 both.",
        //        QuestionTypeId = questionType.Id,
        //        ShuffleAnswers = true,
        //        UserId = "1",
        //        Level = 1,
        //        Tag = "Action"
        //    };
        //    catalogContext.Questions.Add(question);
        //    await catalogContext.SaveChangesAsync();

        //    var answer = new List<Answer>()
        //    {
        //        new Answer() {QuestionId = question.Id, AnswerContent = "under", AllowShuffle =true, IsRight = false},
        //        new Answer() {QuestionId = question.Id, AnswerContent = "in", AllowShuffle =true, IsRight = true},
        //        new Answer() {QuestionId = question.Id, AnswerContent = "after", AllowShuffle = true, IsRight = false},
        //        new Answer() {QuestionId = question.Id, AnswerContent = "over", AllowShuffle = true, IsRight = false},
        //    };
        //    catalogContext.Answers.AddRange(answer);
        //    await catalogContext.SaveChangesAsync();
        //}

        //private static async Task SeedMultipleChoiceQuestion(CatalogContext catalogContext)
        //{
        //    var questionType = new QuestionType() { Name = "MultipleChoice" };
        //    catalogContext.QuestionTypes.Add(questionType);
        //    await catalogContext.SaveChangesAsync();

        //    var question = new Question()
        //    {
        //        QuestionContent = "It’s said that he has____friends of his age.",
        //        QuestionTypeId = questionType.Id,
        //        ShuffleAnswers = true,
        //        UserId = "1"
        //    };
        //    catalogContext.Questions.Add(question);
        //    await catalogContext.SaveChangesAsync();

        //    var answer = new List<Answer>()
        //    {
        //        new Answer() {QuestionId = question.Id, AnswerContent = "few", AllowShuffle =true, IsRight = true},
        //        new Answer() {QuestionId = question.Id, AnswerContent = "some", AllowShuffle =true, IsRight = true},
        //        new Answer() {QuestionId = question.Id, AnswerContent = "plenty", AllowShuffle = true, IsRight = false},
        //        new Answer() {QuestionId = question.Id, AnswerContent = "little", AllowShuffle = true, IsRight = false},
        //    };
        //    catalogContext.Answers.AddRange(answer);
        //    await catalogContext.SaveChangesAsync();
        //}
    }
}