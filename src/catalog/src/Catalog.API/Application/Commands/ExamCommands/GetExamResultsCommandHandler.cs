using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class
        GetExamResultsCommandHandler : IRequestHandler<GetExamResultsCommand,
            Response<PaginationResponse<ExamResultViewModel>>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public GetExamResultsCommandHandler(ILogger<GetExamResultsCommand> logger,
            IExamRepository examRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<Response<PaginationResponse<ExamResultViewModel>>> Handle(GetExamResultsCommand request,
            CancellationToken cancellationToken)
        {
            var query = AppendFilterQuery(request);
            var items = await query
                .OrderBy(x => x.Id)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var total = await query
                .Select(x => x.Id)
                .CountAsync();

            var ExamResults = _mapper.Map<List<ExamResultViewModel>>(items);

            var result = PaginationResponse<ExamResultViewModel>.Success(ErrorCode.Success, ExamResults, total);
            return Response<PaginationResponse<ExamResultViewModel>>.Success(ErrorCode.Success, result);
        }

        private IQueryable<ExamResult> AppendFilterQuery(GetExamResultsCommand request)
        {
            var query = _examRepository.ExamResults
                .Include(x => x.Exam)
                .Where(x => x.Deleted != true);

            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(x => x.CreatedBy == request.UserId);
            }

            query = query.Where(x => !request.Query.CreatedDate.IsValid
                            || string.IsNullOrEmpty(request.Query.CreatedDate.FilterValue)
                            || x.CreatedDate.Date == request.Query.CreatedDate.DateTimeFormatted);

            return query;
        }
    }
}