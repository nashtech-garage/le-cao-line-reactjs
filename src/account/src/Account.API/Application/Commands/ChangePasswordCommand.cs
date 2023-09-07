using Account.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Account.API.Application.Commands
{
    public class ChangePasswordCommand : IRequest<Response<ResponseDefault>>
    {
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
        public string VerifyPassword { get; set; }
    }
}
