using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class SubmitExamCommandHandler : IRequestHandler<SubmitExamCommand, Response<ExamResultViewModel>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public SubmitExamCommandHandler(ILogger<SubmitExamCommand> logger,
            IExamRepository examRepository,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<ExamResultViewModel>> Handle(SubmitExamCommand request,
            CancellationToken cancellationToken)
        {
            // Compute score
            var numberOfCorrectAns = 0;
            var exam = await _examRepository.Exams
                .Where(x => (string.IsNullOrEmpty(request.ExamId) || x.Id == request.ExamId)
                            && x.Deleted != true)
                .Include(x => x.Schedules)
                .Include(x => x.QuestionExams)
                    .ThenInclude(x => x.Question)
                        .ThenInclude(x => x.Answers)
                .SingleOrDefaultAsync();

            var fixedExamIds = new List<string>
            {
                FixedExam.A1Id,
                FixedExam.A2Id,
                FixedExam.A3Id,
                FixedExam.A4Id,
                FixedExam.B1Id,
                FixedExam.B2Id,
                FixedExam.CId,
                FixedExam.DId,
                FixedExam.EId,
                FixedExam.FId,
            };

            if (exam is not null || fixedExamIds.Contains(request.ExamId))
            {
                var questions = new List<Question>();

                if (fixedExamIds.Contains(request.ExamId))
                {
                    var questionIds = request.QuestionAnswers.Select(x => x.QuestionId);
                    questions = _questionRepository.Questions
                        .Where(x => questionIds.Contains(x.Id))
                        .Include(x=>x.Answers).ToList();
                }
                else
                {
                    questions = exam.QuestionExams.Select(x => x.Question).ToList();
                }
                
                if (questions.Any())
                {
                    questions?.ToList().ForEach(x =>
                    {
                        var questionAnswer = request.QuestionAnswers.FirstOrDefault(y => y.QuestionId == x.Id);
                        var correctAnswerIds = x.Answers.Where(x => x.AnswerValue == "true" || x.AnswerValue == "True").Select(x => x.Id);
                        if (correctAnswerIds.Any() && correctAnswerIds.Contains(questionAnswer?.AnswerId))
                        {
                            numberOfCorrectAns++;
                        }
                    });
                    var percentCorrect = numberOfCorrectAns / questions?.Count() * 100;

                    var percentWillPass = exam is not null ? exam.PercentageToPass : ExamGetValue.GetPercent(request.ExamId);
                    var examResult = new ExamResult
                    {
                        UserId = request.UserId,
                        CreatedBy = request.UserId,
                        ExamId = request.ExamId,
                        ResultStatus = percentCorrect >= percentWillPass ? "Passed" : "Failed",
                        NumberOfCorrectAnswer = numberOfCorrectAns
                    };

                    // If anonymous then not store result
                    if (string.IsNullOrEmpty(request.UserId))
                    {
                        var anonymousExamResultViewModel = _mapper.Map<ExamResultViewModel>(examResult);
                        var anoQuestionAnswers = request.QuestionAnswers.ToList().Select(x =>
                            new QuestionAnswerViewModel 
                            { 
                                AnswerId = x.AnswerId, 
                                QuestionId = x.QuestionId
                            });

                        anonymousExamResultViewModel.QuestionAnswers = anoQuestionAnswers.ToList();
                        return Response<ExamResultViewModel>.Success(ErrorCode.Success, anonymousExamResultViewModel);
                    }

                    // Store result
                    _examRepository.Add(examResult);
                    var examResultSaved = await _examRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    if (examResultSaved)
                    {
                        var questionAnswers = _mapper.Map<List<QuestionAnswer>>(request.QuestionAnswers, opts =>
                            opts.Items["examResultId"] = examResult.Id);
                        _examRepository.AddRange(questionAnswers);
                    }
                    var questionAnswersResult = await _examRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

                    if (examResultSaved && questionAnswersResult)
                    {
                        return Response<ExamResultViewModel>.Success(ErrorCode.Success, _mapper.Map<ExamResultViewModel>(examResult));
                    }
                }
            }
            return Response<ExamResultViewModel>.Fail(ErrorCode.InternalError);
        }
    }
}
