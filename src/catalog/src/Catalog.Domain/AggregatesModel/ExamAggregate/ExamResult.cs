using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.ExamAggregate
{
    public class ExamResult : Entity, IAggregateRoot
    {
        public string ExamId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string ResultStatus { get; set; } = null!; // Failed or Passed
        public int NumberOfCorrectAnswer { get; set; }
        

        public virtual Exam Exam { get; set; }
        public virtual List<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
