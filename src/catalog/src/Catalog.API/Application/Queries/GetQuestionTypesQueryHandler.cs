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
        GetQuestionTypesQueryHandler : IRequestHandler<GetQuestionTypesQuery, Response<List<QuestionTypesViewModel>>>
    {
        private readonly ILogger _logger;
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetQuestionTypesQueryHandler(ILogger<GetQuestionTypesQuery> logger,
            IQuestionRepository questionRepository,
            IMapper mapper)
        {
            _logger = logger;
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<Response<List<QuestionTypesViewModel>>> Handle(GetQuestionTypesQuery request,
            CancellationToken cancellationToken)
        {
            var items = await _questionRepository.QuestionTypes.Where(x => x.Deleted != true).OrderBy(x => x.Name)
                .ToListAsync(cancellationToken: cancellationToken);
            if (items is null || items.Count == 0)
                return Response<List<QuestionTypesViewModel>>.Fail(ErrorCode.InternalError);
            var result = _mapper.Map<List<QuestionTypesViewModel>>(items);

            return Response<List<QuestionTypesViewModel>>.Success(ErrorCode.Success, result);
        }
    }
}