using AutoMapper;
using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Application.Queries
{
    public class
        GetQuestionLevelsQueryHandler : IRequestHandler<GetQuestionLevelsQuery, Response<List<QuestionLevelsViewModel>>>
    {
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionLevelsQueryHandler(ILogger<GetQuestionTypesQuery> logger,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<QuestionLevelsViewModel>>> Handle(GetQuestionLevelsQuery request,
            CancellationToken cancellationToken)
        {
            var items = await _questionRepository.Levels.Where(x => x.Deleted != true).OrderBy(x => x.Id)
                .ToListAsync(cancellationToken: cancellationToken);
            if (items is null || items.Count == 0)
                return Response<List<QuestionLevelsViewModel>>.Fail(ErrorCode.InternalError);
            var result = _mapper.Map<List<QuestionLevelsViewModel>>(items);

            return Response<List<QuestionLevelsViewModel>>.Success(ErrorCode.Success, result);
        }
    }
}