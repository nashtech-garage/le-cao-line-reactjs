using AutoMapper;
using Catalog.API.Application.Commands.QuestionCommands;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class GetExamResultByIdCommandHandler : IRequestHandler<GetExamResultByIdCommand, Response<ExamResultViewModel>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetExamResultByIdCommandHandler(ILogger<GetExamResultByIdCommand> logger,
            IExamRepository examRepository,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<ExamResultViewModel>> Handle(GetExamResultByIdCommand request,
            CancellationToken cancellationToken)
        {
            var exam = await _examRepository.ExamResults
                .Where(x => x.Id == request.ExamResultId && x.Deleted != true)
                .Include(x => x.Exam)
                .Include(x => x.QuestionAnswers)
                .SingleOrDefaultAsync();

            if (exam is null)
                return Response<ExamResultViewModel>.Fail(ErrorCode.InternalError);

            var examResult = _mapper.Map<ExamResultViewModel>(exam);

            var questionIds = exam.QuestionAnswers.Select(x => x.QuestionId);
            var questions = _questionRepository.Questions
                .Where(x=> questionIds.Contains(x.Id))
                .Include(x => x.Answers)
                .ToList();
            var questionViewModels = _mapper.Map<List<QuestionViewModel>>(questions);

            if (questionViewModels != null && questionViewModels.Any()){
                examResult.Questions = questionViewModels;
            }

            return Response<ExamResultViewModel>.Success(ErrorCode.Success, examResult);
        }
    }
}
