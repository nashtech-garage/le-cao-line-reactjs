using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.ExamAggregate
{
    public class QuestionAnswer : Entity, IAggregateRoot
    {
        public string ExamResultId { get; set; } = null!;
        public string QuestionId { get; set; } = null!;
        public string AnswerId { get; set; }

        public virtual ExamResult ExamResult { get; set; }
    }
}
