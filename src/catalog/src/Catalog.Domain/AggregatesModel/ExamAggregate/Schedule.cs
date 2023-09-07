using Catalog.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.AggregatesModel.ExamAggregate
{
    public class Schedule : Entity, IAggregateRoot
    {
        public string Code { get; set; }
        public int Time { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }

        public string ExamId { get; set; }

        public Exam Exam { get; set; }
    }
}
