namespace Catalog.API.Models
{
    public class QuestionAnswerViewModel
    {
        public string ExamResultId { get; set; } = null!;
        public string QuestionId { get; set; } = null!;
        public string AnswerId { get; set; }

        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
