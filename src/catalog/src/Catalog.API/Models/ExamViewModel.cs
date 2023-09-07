namespace Catalog.API.Models
{
    public class ExamViewModel
    {
        public string Id { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DefaultQuestionNumber { get; set; }
        public int PlusScorePerQuestion { get; set; }
        public int MinusScorePerQuestion { get; set; }
        public bool ViewPassQuestion { get; set; }
        public bool ViewNextQuestion { get; set; }
        public bool ShowAllQuestion { get; set; }
        public int TimePerQuestion { get; set; }
        public int ShufflingExams { get; set; }
        public bool HideResult { get; set; }
        public int PercentageToPass { get; set; }

        public List<ScheduleViewModel> Schedules { get; set; }
        public List<QuestionViewModel> Questions { get; set; }

        public ExamViewModel()
        {
            Schedules = new List<ScheduleViewModel>();
            Questions = new List<QuestionViewModel>();
            ViewPassQuestion = true;
            ViewNextQuestion = true;
            HideResult = true;
        }

        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
