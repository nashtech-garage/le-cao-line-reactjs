using Catalog.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Catalog.API.Application.Commands
{
    public class CreateCommand : IRequest<Response<ResponseDefault>>
    {
        public int Id { get; set; }
    }
}