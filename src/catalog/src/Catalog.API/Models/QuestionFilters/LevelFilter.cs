using Catalog.Domain.Constants;

namespace Catalog.API.Models.QuestionFilters
{
    public class LevelFilter : QuestionFilterBase
    {
        public override QuestionTypeFilterConstant FilterType =>
            FilterValue != null ? QuestionTypeFilterConstant.Level : QuestionTypeFilterConstant.None;

        public int? FilterValue { get; set; }
    }
}