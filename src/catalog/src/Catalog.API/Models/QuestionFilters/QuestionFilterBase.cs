using Catalog.Domain.Constants;

namespace Catalog.API.Models.QuestionFilters
{
    public abstract class QuestionFilterBase
    {
        public virtual QuestionTypeFilterConstant FilterType { get; }
        public bool IsValid => FilterType != QuestionTypeFilterConstant.None;
    }
}