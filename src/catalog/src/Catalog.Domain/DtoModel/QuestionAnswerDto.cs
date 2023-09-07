using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.DtoModel
{
    public class QuestionAnswerDto
    {
        public string? Id { get; set; }
        public string? ExamResultId { get; set; }
        public string AnswerId { get; set; } = null!;
        public string QuestionId { get; set; } = null!;
    }
}
