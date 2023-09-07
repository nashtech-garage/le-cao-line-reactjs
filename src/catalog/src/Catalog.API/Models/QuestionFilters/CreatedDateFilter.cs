using Catalog.Domain.Constants;

namespace Catalog.API.Models.QuestionFilters
{
    public class CreatedDateFilter : QuestionFilterBase
    {
        public override QuestionTypeFilterConstant FilterType => !string.IsNullOrEmpty(FilterValue)
            ? QuestionTypeFilterConstant.CreatedDate
            : QuestionTypeFilterConstant.None;

        public string FilterValue { get; set; } = string.Empty;

        public DateTime DateTimeFormatted
        {
            get
            {
                var formatValue = IsValid ? DateTimeOffset.Parse(FilterValue).UtcDateTime.Date : default(DateTime);
                return formatValue;
            }
        }
    }
}