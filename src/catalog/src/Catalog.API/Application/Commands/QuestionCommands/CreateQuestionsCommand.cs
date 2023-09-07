using Catalog.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class CreateQuestionsCommand : IRequest<Response<ResponseDefault>>
    {
        public IEnumerable<CreateQuestionCommand> CreateQuestionCommands { get; set; }
        public CreateQuestionsCommand()
        {
            CreateQuestionCommands = new List<CreateQuestionCommand>();
        }
    }
}
