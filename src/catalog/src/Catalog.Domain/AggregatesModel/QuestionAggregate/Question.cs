using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.QuestionAggregate
{
    public class Question : Entity, IAggregateRoot
    {
        public string QuestionContent { get; set; } = null!;
        public string QuestionTypeId { get; set; }
        public string LevelId { get; set; }
        public string UserId { get; set; }
        public bool ShuffleAnswers { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual List<Answer> Answers { get; set; }
        public virtual Level Level { get; set; }    
        public virtual List<TagQuestion> TagQuestions { get; set; }
        public virtual List<QuestionExam> QuestionExams { get; set; }
    }
}