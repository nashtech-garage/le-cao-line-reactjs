using Catalog.Domain.Constants;

namespace Catalog.API.Models.QuestionFilters
{
    public class TagFilter : QuestionFilterBase
    {
        public override QuestionTypeFilterConstant FilterType => !string.IsNullOrEmpty(FilterValue)
            ? QuestionTypeFilterConstant.Tag
            : QuestionTypeFilterConstant.None;

        public string FilterValue { get; set; } = string.Empty;
    }
}