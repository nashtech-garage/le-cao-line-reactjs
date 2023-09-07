using Account.API.Application.IntegrationEvents.Events;
using Account.API.Infrastructure.ResponseGeneric;
using Account.API.Infrastructure.Services;
using Account.Domain.AggregatesModel;
using MediatR;

namespace Account.API.Application.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response<TokenResponse>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly IKeycloakService _keycloakService;
        private readonly IMediator _mediator;
        public LoginCommandHandler(IUserRepository userRepository, IIdentityService identityService, IKeycloakService keycloakService, IMediator mediator)
        {
            _userRepository = userRepository;
            _identityService = identityService;
            _keycloakService = keycloakService;
            _mediator = mediator;
        }

        public async Task<Response<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var response = await _keycloakService.UserLogin(request.Username, request.Password);
            if(response is null)
            {
                return new Response<TokenResponse>()
                {
                    State = false,
                    Message = ErrorCode.BadRequest
                };
            }

            // send notification
            var user = _identityService.GetIdentityUser(response.access_token);
            var sendNotifyCommand = new SendNotifiyCommand()
            {
                EventId = "LoginNotifyIntegrationEvent",
                EventData = new LoginNotifyIntegrationEvent()
                {
                    Email = user.Email,
                    UserIp = _identityService.GetUserIp(),
                    FullName = user.Name,
                }
            };

            await _mediator.Send(sendNotifyCommand);

            return new Response<TokenResponse>()
            {
                State = true,
                Message = ErrorCode.Success,
                Object = new TokenResponse()
                {
                    AccessToken = response.access_token,
                    Expires = response.expires_in,
                    Email = user.Email,
                    FirstName = user.Name,
                    LastName = user.FamilyName,
                    Roles = user.Roles,
                }
            };
        }
    }
}
