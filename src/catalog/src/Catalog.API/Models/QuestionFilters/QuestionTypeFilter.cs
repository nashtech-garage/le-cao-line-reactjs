using Catalog.Domain.Constants;

namespace Catalog.API.Models.QuestionFilters
{
    public class QuestionTypeFilter : QuestionFilterBase
    {
        public override QuestionTypeFilterConstant FilterType => FilterValue != null
            ? QuestionTypeFilterConstant.QuestionType
            : QuestionTypeFilterConstant.None;

        public string? FilterValue { get; set; }
    }
}