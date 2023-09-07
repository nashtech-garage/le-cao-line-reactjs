using AutoMapper;
using Catalog.API.Application.Commands.QuestionCommands;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using Catalog.Infrastructure.Repositories;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, Response<ResponseDefault>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public CreateExamCommandHandler(ILogger<CreateExamCommand> logger,
            IExamRepository examRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<Response<ResponseDefault>> Handle(CreateExamCommand request,
            CancellationToken cancellationToken)
        {
            var exam = _mapper.Map<Exam>(request.Exam);
            exam.CreatedBy = request.UserId;
            _examRepository.Add(exam);
            var examResult = await _examRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

            if (examResult)
            {
                var questionExams = new List<QuestionExam>();
                request.Exam.Questions.ToList().ForEach(x =>
                {
                    var questionExam = new QuestionExam
                    {
                        QuestionId = x
                    };
                    questionExams.Add(questionExam);
                });
                questionExams.ForEach(x => x.ExamId = exam.Id);
                _examRepository.AddRange(questionExams);

                var schedules = _mapper.Map<List<Schedule>>(request.Exam.Schedules, opts =>
                    opts.Items["examId"] = exam.Id);
                _examRepository.AddRange(schedules);
            }
            var questionExams_and_SchduleResult = await _examRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);


            if (examResult && questionExams_and_SchduleResult)
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
