using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class UpdateQuestionCommand : IRequest<Response<ResponseDefault>>
    {
        public string Id { get; set; } = null!;
        public string QuestionContent { get; set; } = null!;
        public bool ShuffleAnswers { get; set; }
        public string LevelId { get; set; } = "7b70ddba-b8b0-42f8-961e-20785f0f564b";
        public string UserId { get; set; } = "c4c93c76-e6bf-4608-8e84-dce4a1625fad";

        public IEnumerable<AnswerDto> Answers { get; set; } = null!;

        public UpdateQuestionCommand()
        {
            Answers = new List<AnswerDto>();
        }
    }
}