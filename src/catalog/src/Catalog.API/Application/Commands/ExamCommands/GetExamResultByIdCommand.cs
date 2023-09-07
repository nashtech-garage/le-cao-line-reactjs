using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class GetExamResultByIdCommand : IRequest<Response<ExamResultViewModel>>
    {
        public string ExamResultId { get; set; }
    }
}
