using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.QuestionAggregate
{
    public class QuestionType : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public List<Question> Questions { get; set; }
    }
}