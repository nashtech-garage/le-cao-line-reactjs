using Catalog.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class RemoveExamCommand : IRequest<Response<ResponseDefault>>
    {
        public string ExamId { get; set; }
    }
}
