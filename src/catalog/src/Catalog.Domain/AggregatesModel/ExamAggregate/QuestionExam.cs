using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.AggregatesModel.ExamAggregate
{
    public class QuestionExam : Entity
    {
        public string ExamId { get; set; }
        public string QuestionId { get; set; }

        public Question Question { get; set; }
        public Exam Exam { get; set; }
    }
}
