using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class
        GetQuestionsCommandHandler : IRequestHandler<GetQuestionsCommand,
            Response<PaginationResponse<QuestionViewModel>>>
    {
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionsCommandHandler(ILogger<GetQuestionsCommand> logger,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<PaginationResponse<QuestionViewModel>>> Handle(GetQuestionsCommand request,
            CancellationToken cancellationToken)
        {
            var query = AppendFilterQuery(request);
            var items = await query
                .OrderByDescending(x => x.CreatedDate)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            var total = await query
                .Select(x => x.Id)
                .CountAsync();

            var questions = _mapper.Map<List<QuestionViewModel>>(items);

            var result = PaginationResponse<QuestionViewModel>.Success(ErrorCode.Success, questions, total);
            return Response<PaginationResponse<QuestionViewModel>>.Success(ErrorCode.Success, result);
        }

        private IQueryable<Question> AppendFilterQuery(GetQuestionsCommand request)
        {
            var query = _questionRepository.Questions
                .Where(x => x.Deleted != true);

            if (!string.IsNullOrEmpty(request.UserId))
            {
                query = query.Where(x => x.CreatedBy == request.UserId);
            }

            query = query.Where(x => !request.Query.Keyword.IsValid
                            || string.IsNullOrEmpty(request.Query.Keyword.FilterValue)
                            || x.QuestionContent == request.Query.Keyword.FilterValue)
                .Where(x => !request.Query.QuestionType.IsValid
                            || string.IsNullOrEmpty(request.Query.QuestionType.FilterValue)
                            || x.QuestionTypeId == request.Query.QuestionType.FilterValue)
                .Where(x => !request.Query.CreatedDate.IsValid
                            || string.IsNullOrEmpty(request.Query.CreatedDate.FilterValue)
                            || x.CreatedDate.Date == request.Query.CreatedDate.DateTimeFormatted)
                .Include(x => x.TagQuestions).ThenInclude(x => x.Tag)
                .Include(x => x.Level)
                .Include(x => x.QuestionType);
            //.Where(x => !request.Query.Tag.IsValid || x.Tag == request.Query.Tag.FilterValue)
            //.Where(x => !request.Query.Level.IsValid || x.Level == request.Query.Level.FilterValue);

            return query;
        }
    }
}