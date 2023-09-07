using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class TakeExamCommand : IRequest<Response<ExamViewModel>>
    {
        public string ExamId { get; set; }
    }
}
