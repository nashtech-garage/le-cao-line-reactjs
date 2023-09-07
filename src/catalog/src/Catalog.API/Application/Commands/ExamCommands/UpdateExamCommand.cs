using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class UpdateExamCommand : IRequest<Response<ResponseDefault>>
    {
        public string ExamId { get; set; } = null!;

        public ExamDto Exam { get; set; } = null!;

        public UpdateExamCommand()
        {
            Exam = new ExamDto();
        }
    }
}
