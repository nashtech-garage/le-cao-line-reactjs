using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class RemoveExamCommandHandler : IRequestHandler<RemoveExamCommand, Response<ResponseDefault>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;

        public RemoveExamCommandHandler(ILogger<RemoveExamCommand> logger,
            IExamRepository examRepository)
        {
            _logger = logger;
            _examRepository = examRepository;
        }

        public async Task<Response<ResponseDefault>> Handle(RemoveExamCommand request,
            CancellationToken cancellationToken)
        {
            var exam = _examRepository.Exams.FirstOrDefault(q => q.Id == request.ExamId);
            if (exam is null)
            {
                return Response<ResponseDefault>.Fail(ErrorCode.InternalError);
            }

            exam.Deleted = true;
            exam.DeletedDate = DateTime.UtcNow;
            _examRepository.Update(exam);

            var result = await _examRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            if (result)
            {
                return Response<ResponseDefault>.Success(ErrorCode.Success, new ResponseDefault()
                {
                    Data = exam.Id.ToString()
                });
            }

            return Response<ResponseDefault>.Fail(ErrorCode.InternalError);
        }
    }
}
