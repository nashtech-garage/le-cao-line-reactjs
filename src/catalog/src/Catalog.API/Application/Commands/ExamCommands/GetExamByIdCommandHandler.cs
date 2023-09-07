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
    public class GetExamByIdCommandHandler : IRequestHandler<GetExamByIdCommand, Response<ExamViewModel>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public GetExamByIdCommandHandler(ILogger<GetExamByIdCommand> logger,
            IExamRepository examRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<Response<ExamViewModel>> Handle(GetExamByIdCommand request,
            CancellationToken cancellationToken)
        {
            var exam = await _examRepository.Exams
                .Where(x => (string.IsNullOrEmpty(request.ExamId) || x.Id == request.ExamId)
                            && x.Deleted != true)
                .Include(x => x.Schedules)
                .Include(x => x.QuestionExams)
                    .ThenInclude(x => x.Question)
                        .ThenInclude(x=>x.Answers)
                .SingleOrDefaultAsync();

            if (exam is null)
                return Response<ExamViewModel>.Fail(ErrorCode.InternalError);

            var questionResult = _mapper.Map<ExamViewModel>(exam);

            return Response<ExamViewModel>.Success(ErrorCode.Success, questionResult);
        }
    }
}
