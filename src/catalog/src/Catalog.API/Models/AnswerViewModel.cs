namespace Catalog.API.Models
{
    public class AnswerViewModel
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public string AnswerContent { get; set; }
        public string AnswerValue { get; set; }
        public bool AllowShuffle { get; set; }
        public int MatchingPosition { get; set; }
    }
}