namespace Catalog.Domain.DtoModel
{
    public class AnswerDto
    {
        public string? Id { get; set; }
        public string? QuestionId { get; set; }
        public string AnswerContent { get; set; } = null!;
        public string AnswerValue { get; set; } = null!;
        public bool AllowShuffle { get; set; }
        public int MatchingPosition { get; set; }
    }
}