using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class GetQuestionByIdCommand : IRequest<Response<QuestionViewModel>>
    {
        public string UserId { get; set; }
        public string QuestionId { get; set; }
    }
}