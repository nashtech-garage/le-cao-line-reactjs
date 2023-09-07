using Catalog.API.Infrastructure.ResponseGeneric;
using Catalog.API.Models;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.DtoModel;
using MediatR;

namespace Catalog.API.Application.Queries
{
    public class GetQuestionTypesQuery : BaseQueryDto, IRequest<Response<List<QuestionTypesViewModel>>>
    {
    }
}