using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.QuestionAggregate
{
    public class Answer : Entity
    {
        public string AnswerContent { get; set; }
        public string AnswerValue { get; set; }
        public string QuestionId { get; set; }
        public bool AllowShuffle { get; set; }
        public int MatchingPosition { get; set; }
        public Question Question { get; set; }
    }
}