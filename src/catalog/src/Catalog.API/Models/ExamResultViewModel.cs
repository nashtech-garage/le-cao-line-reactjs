namespace Catalog.API.Models
{
    public class ExamResultViewModel
    {
        public string Id { get; set; }
        public string ExamId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string? ExamName { get; set; }
        public string ResultStatus { get; set; }
        public int NumberOfCorrectAnswer { get; set; }
        public IList<QuestionAnswerViewModel> QuestionAnswers { get; set; }
        public IList<QuestionViewModel> Questions { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
