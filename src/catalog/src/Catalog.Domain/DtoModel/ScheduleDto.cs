using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.DtoModel
{
    public class ScheduleDto
    {
        public string? Id { get; set; }
        public string? ExamId { get; set; }
        public string Code { get; set; }
        public int Time { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Status { get; set; }

        public string UserId { get; set; } = "c4c93c76-e6bf-4608-8e84-dce4a1625fad";
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; } = "c4c93c76-e6bf-4608-8e84-dce4a1625fad";
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
