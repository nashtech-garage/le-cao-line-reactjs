using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand, Response<ResponseDefault>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public UpdateExamCommandHandler(ILogger<UpdateExamCommand> logger,
            IExamRepository examRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<Response<ResponseDefault>> Handle(UpdateExamCommand request,
            CancellationToken cancellationToken)
        {
            var exam = await _examRepository.Exams
                .Where(q => q.Id == request.ExamId)
                .Include(x => x.Schedules)
                .Include(x => x.QuestionExams)
                .FirstOrDefaultAsync();

            if (exam is null)
            {
                return Response<ResponseDefault>.Fail(ErrorCode.InternalError);
            }

            exam.Code = request.Exam.Code;
            exam.Name = request.Exam.Name;
            exam.Description = request.Exam.Description;
            exam.DefaultQuestionNumber = request.Exam.DefaultQuestionNumber;
            exam.PlusScorePerQuestion = request.Exam.PlusScorePerQuestion;
            exam.MinusScorePerQuestion = request.Exam.MinusScorePerQuestion;
            exam.ViewPassQuestion = request.Exam.ViewPassQuestion;
            exam.ViewNextQuestion = request.Exam.ViewNextQuestion;
            exam.ShowAllQuestion = request.Exam.ShowAllQuestion;
            exam.TimePerQuestion = request.Exam.TimePerQuestion;
            exam.ShufflingExams = request.Exam.ShufflingExams;
            exam.HideResult = request.Exam.HideResult;
            exam.PercentageToPass = request.Exam.PercentageToPass;

            var removedScheduleIds = new List<string>();
            if (exam.Schedules != null)
            {
                // remove or update existing schedule
                exam.Schedules.ForEach(x =>
                {
                    var updatedItem = request.Exam.Schedules
                        .FirstOrDefault(y => x.Id != null && x.Id == y.Id);
                    if (updatedItem is null)
                    {
                        removedScheduleIds.Add(x.Id);
                    }
                    else
                    {
                        x.Code = updatedItem.Code;
                        x.Time = updatedItem.Time;
                        x.StartTime = updatedItem.StartTime;
                        x.EndTime = updatedItem.EndTime;
                        x.Status = updatedItem.Status;
                    }
                });
                var removedSchedules = exam.Schedules.Where(x => removedScheduleIds.Contains(x.Id)).ToList();
                removedSchedules.ForEach(x => exam.Schedules.Remove(x));

                // add new schedule 
                var newSchedules = request.Exam.Schedules.Where(x => string.IsNullOrEmpty(x.Id));
                var schedules = _mapper.Map<List<Schedule>>(newSchedules, opts =>
                    opts.Items["examId"] = exam.Id);
                _examRepository.AddRange(schedules);
            }
            _examRepository.Update(exam);
            var examResult = await _examRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            request.Exam.Questions.ToList().ForEach(questionId =>
            {
                var existingQuestionExam = exam.QuestionExams.FirstOrDefault(y => y.QuestionId == questionId);
                if (existingQuestionExam is null)
                {
                    var newQuestionExam = new QuestionExam
                    {
                        ExamId = request.ExamId,
                        QuestionId = questionId
                    };

                    exam.QuestionExams.Add(newQuestionExam);
                }
            });
            exam.QuestionExams.RemoveAll(x => !request.Exam.Questions.Contains(x.QuestionId));
            _examRepository.Update(exam);
            var questionExamResult = await _examRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (examResult && questionExamResult)
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
