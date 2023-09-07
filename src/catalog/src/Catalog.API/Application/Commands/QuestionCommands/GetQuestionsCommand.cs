using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.API.Models.QuestionFilters;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.QuestionCommands
{
    public class GetQuestionsCommand : BaseQueryDto, IRequest<Response<PaginationResponse<QuestionViewModel>>>
    {
        public string? UserId { get; set; }
        public FilterQuery Query { get; set; } = new();
    }

    public class FilterQuery
    {
        public KeywordFilter Keyword { get; set; } = new();
        public QuestionTypeFilter QuestionType { get; set; } = new();
        public CreatedDateFilter CreatedDate { get; set; } = new();
        public LevelFilter Level { get; set; } = new();
        public TagFilter Tag { get; set; } = new();
    }
}