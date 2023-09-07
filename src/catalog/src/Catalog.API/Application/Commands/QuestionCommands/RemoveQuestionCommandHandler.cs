using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class RemoveQuestionCommandHandler : IRequestHandler<RemoveQuestionCommand, Response<ResponseDefault>>
    {
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;

        public RemoveQuestionCommandHandler(ILogger<RemoveQuestionCommand> logger,
            IQuestionRepository questionRepository)
        {
            _logger = logger;
            _questionRepository = questionRepository;
        }

        public async Task<Response<ResponseDefault>> Handle(RemoveQuestionCommand request,
            CancellationToken cancellationToken)
        {
            var question = _questionRepository.Questions.FirstOrDefault(q => q.Id == request.QuestionId);
            if (question is null)
            {
                return Response<ResponseDefault>.Fail(ErrorCode.InternalError);
            }

            question.Deleted = true;
            question.DeletedDate = DateTime.UtcNow;
            _questionRepository.Update(question);

            var result = await _questionRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
            if (result)
            {
                return Response<ResponseDefault>.Success(ErrorCode.Success, new ResponseDefault()
                {
                    Data = question.Id.ToString()
                });
            }

            return Response<ResponseDefault>.Fail(ErrorCode.InternalError);
        }
    }
}