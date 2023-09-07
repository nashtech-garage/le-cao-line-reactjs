namespace Catalog.API.Models
{
    public class QuestionViewModel
    {
        public string Id { get; set; } = null!;
        public string QuestionContent { get; set; } = null!;
        public string QuestionTypeId { get; set; }
        public string LevelId { get; set; }
        public bool ShuffleAnswers { get; set; }
        public string UserId { get; set; }
        public string QuestionType { get; set; }
        public string Level { get; set; }
        public IEnumerable<string> TagQuestions { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public List<AnswerViewModel> Answers { get; set; }

        public QuestionViewModel()
        {
            TagQuestions = new List<string>();
            Answers = new List<AnswerViewModel>();
        }
    }
}