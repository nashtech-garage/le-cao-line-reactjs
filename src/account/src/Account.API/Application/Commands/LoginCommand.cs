using Account.API.Infrastructure.ResponseGeneric;
using MediatR;

namespace Account.API.Application.Commands
{
    public class LoginCommand : IRequest<Response<TokenResponse>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
