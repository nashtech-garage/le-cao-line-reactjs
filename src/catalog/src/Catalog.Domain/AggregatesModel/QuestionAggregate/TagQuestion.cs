using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.QuestionAggregate
{
    public class TagQuestion : Entity
    {
        public string TagId { get; set; }
        public string QuestionId { get; set; }

        public Question Question { get; set; }
        public Tag Tag { get; set; }
    }
}