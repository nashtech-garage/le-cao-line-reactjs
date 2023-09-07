using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.API.Models.QuestionFilters;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Commands.ExamCommands
{
    public class GetExamsCommand : BaseQueryDto, IRequest<Response<PaginationResponse<ExamViewModel>>>
    {
        public string? UserId { get; set; }
        public ExamFilterQuery Query { get; set; } = new();
    }

    public class ExamFilterQuery
    {
        public KeywordFilter Keyword { get; set; } = new();
        public CreatedDateFilter CreatedDate { get; set; } = new();
    }
}