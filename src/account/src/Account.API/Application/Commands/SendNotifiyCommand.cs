using Account.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Account.API.Application.Commands
{
    public class SendNotifiyCommand : IRequest<Response<ResponseDefault>>
    {
        public string EventId { get; set; }
        public object EventData { get; set; } = null!;
    }
}
