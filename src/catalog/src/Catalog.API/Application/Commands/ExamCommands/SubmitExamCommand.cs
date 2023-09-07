using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class SubmitExamCommand : IRequest<Response<ExamResultViewModel>>
    {
        public string UserId { get; set; } = "c4c93c76-e6bf-4608-8e84-dce4a1625fad";
        public string ExamId { get; set; }
        public IList<QuestionAnswerDto> QuestionAnswers { get; set; }
    }
}
