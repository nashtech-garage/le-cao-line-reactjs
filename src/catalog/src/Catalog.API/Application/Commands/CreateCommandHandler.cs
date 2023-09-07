using Catalog.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Catalog.API.Application.Commands
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand, Response<ResponseDefault>>
    {
        public async Task<Response<ResponseDefault>> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;
            return Response<ResponseDefault>.Success();
        }
    }
}