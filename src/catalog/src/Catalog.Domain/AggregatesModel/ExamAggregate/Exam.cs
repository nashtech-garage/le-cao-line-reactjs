using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using Catalog.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.AggregatesModel.ExamAggregate
{
    public class Exam : Entity, IAggregateRoot
    {
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

        public virtual List<Schedule> Schedules { get; set; }
        public virtual List<QuestionExam> QuestionExams { get; set; }
        public virtual List<ExamResult> ExamResults { get; set; }
    }
}
