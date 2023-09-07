using MediatR;
using Notification.API.Infrastructure.ResponseGeneric;

namespace Notification.API.Application.Commands
{
    public class SendMailCommand : IRequest<Response<ResponseDefault>>
    {
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Body { get; set; }
    }
}
