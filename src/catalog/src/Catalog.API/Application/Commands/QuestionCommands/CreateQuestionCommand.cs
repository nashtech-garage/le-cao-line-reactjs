using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class CreateQuestionCommand : IRequest<Response<ResponseDefault>>
    {
        public string QuestionContent { get; set; } = null!;
        public bool ShuffleAnswers { get; set; }
        public string QuestionTypeId { get; set; } = "6f01c413-497a-4745-93d4-4e41d254fdad";
        public string LevelId { get; set; } = "7b70ddba-b8b0-42f8-961e-20785f0f564b";
        public string UserId { get; set; }
        public IList<string>? TagNames { get; set; }
        public IEnumerable<AnswerDto> Answers { get; set; } = null!;
    }
}