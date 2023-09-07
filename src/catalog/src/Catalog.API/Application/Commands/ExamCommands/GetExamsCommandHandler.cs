using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class
        GetExamsCommandHandler : IRequestHandler<GetExamsCommand,
            Response<PaginationResponse<ExamViewModel>>>
    {
        private readonly ILogger _logger;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public GetExamsCommandHandler(ILogger<GetExamsCommand> logger,
            IExamRepository examRepository,
            IMapper mapper)
        {
            _logger = logger;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<Response<PaginationResponse<ExamViewModel>>> Handle(GetExamsCommand request,
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

            var Exams = _mapper.Map<List<ExamViewModel>>(items);

            var result = PaginationResponse<ExamViewModel>.Success(ErrorCode.Success, Exams, total);
            return Response<PaginationResponse<ExamViewModel>>.Success(ErrorCode.Success, result);
        }

        private IQueryable<Exam> AppendFilterQuery(GetExamsCommand request)
        {
            var query = _examRepository.Exams
                .Where(x => x.Deleted != true);

            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(x => x.CreatedBy == request.UserId);
            }

            query = query.Where(x => x.Deleted != true)
                .Where(x => !request.Query.Keyword.IsValid
                            || string.IsNullOrEmpty(request.Query.Keyword.FilterValue)
                            || x.Name == request.Query.Keyword.FilterValue)
                .Where(x => !request.Query.CreatedDate.IsValid
                            || string.IsNullOrEmpty(request.Query.CreatedDate.FilterValue)
                            || x.CreatedDate.Date == request.Query.CreatedDate.DateTimeFormatted);

            return query;
        }
    }
}