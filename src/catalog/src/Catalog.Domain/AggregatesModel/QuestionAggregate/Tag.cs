using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.QuestionAggregate
{
    public class Tag : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<TagQuestion> TagQuestions { get; set; }
    }
}