using Catalog.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands.CopyQuestion
{
    public class CopyQuestionCommand : IRequest<Response<ResponseDefault>>
    {
        public string QuestionId { get; set; }
    }
}