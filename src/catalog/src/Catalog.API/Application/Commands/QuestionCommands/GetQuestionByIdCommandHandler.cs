using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class GetQuestionByIdCommandHandler : IRequestHandler<GetQuestionByIdCommand, Response<QuestionViewModel>>
    {
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionByIdCommandHandler(ILogger<GetQuestionByIdCommand> logger,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<QuestionViewModel>> Handle(GetQuestionByIdCommand request,
            CancellationToken cancellationToken)
        {
            var question = await _questionRepository.Questions
                .Where(x => (string.IsNullOrEmpty(request.UserId) || x.UserId == request.UserId)
                            && (string.IsNullOrEmpty(request.QuestionId) || x.Id == request.QuestionId)
                            && x.Deleted != true)
                .Include(x => x.Answers)
                .SingleOrDefaultAsync();

            if (question is null)
                return Response<QuestionViewModel>.Fail(ErrorCode.InternalError);

            var questionResult = _mapper.Map<QuestionViewModel>(question);

            return Response<QuestionViewModel>.Success(ErrorCode.Success, questionResult);
        }
    }
}