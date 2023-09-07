using Catalog.Domain.Constants;

namespace Catalog.API.Models.QuestionFilters
{
    public class KeywordFilter : QuestionFilterBase
    {
        public override QuestionTypeFilterConstant FilterType => !string.IsNullOrEmpty(FilterValue)
            ? QuestionTypeFilterConstant.Keyword
            : QuestionTypeFilterConstant.None;

        public string FilterValue { get; set; } = string.Empty;
    }
}