using Catalog.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class RemoveQuestionCommand : IRequest<Response<ResponseDefault>>
    {
        public string QuestionId { get; set; }
    }
}