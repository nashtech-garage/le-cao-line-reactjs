using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.DtoModel
{
    public class ExamDto
    {
        public string? Id { get; set; }
        public string Code { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int DefaultQuestionNumber { get; set; }
        public IList<string> Questions { get; set; } = null!;
        public int PlusScorePerQuestion { get; set; }
        public int MinusScorePerQuestion { get; set; }
        public bool ViewPassQuestion { get; set; }
        public bool ViewNextQuestion { get; set; }
        public bool ShowAllQuestion { get; set; }
        public int TimePerQuestion { get; set; }
        public int ShufflingExams { get; set; }
        public bool HideResult { get; set; }
        public int PercentageToPass { get; set; }
        public IList<ScheduleDto> Schedules { get; set; } = null!;

        public string UserId { get; set; } = "c4c93c76-e6bf-4608-8e84-dce4a1625fad";
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; } = "c4c93c76-e6bf-4608-8e84-dce4a1625fad";
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }

        public ExamDto()
        {
            Schedules = new List<ScheduleDto>();
            Questions = new List<string>();
        }
    }
}
