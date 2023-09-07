using Account.API.Application.IntegrationEvents.Events;
using Account.API.Infrastructure.ResponseGeneric;
using Account.API.Infrastructure.Services;
using Account.API.Models;
using Account.Domain.AggregatesModel;
using MediatR;
using static Account.API.Models.KeyCloakApi;

namespace Account.API.Application.Commands
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, Response<ResponseDefault>>
    {
        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly IKeycloakAdminService _keycloakAdminService;

        public RegisterUserCommandHandler(IUserRepository userRepository, IIdentityService identityService, IKeycloakAdminService keycloakAdminService, IMediator mediator)
        {
            _userRepository = userRepository;
            _identityService = identityService;
            _keycloakAdminService = keycloakAdminService;
            _mediator = mediator;
        }

        public async Task<Response<ResponseDefault>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserRepresentation()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                EmailVerified = true,
                Enabled = true,
                Username = request.Username
            };

            var response = await _keycloakAdminService.CreateUser(user);
            if (!response)
            {
                return Response<ResponseDefault>.Fail();
            }

            var keyCloakUser = await _keycloakAdminService.GetUserByUsername(user.Username);
            if(keyCloakUser is null)
            {
                return Response<ResponseDefault>.Fail();
            }
            var body = new CredentialRepresentation()
            {
                Temporary = false,
                Type = "password",
                Value = request.Password
            };
            
            var updateSuccess = await _keycloakAdminService.ResetPassword(keyCloakUser.Id, body);

            // send notification
            var sendNotifyCommand = new SendNotifiyCommand()
            {
                EventId = "UserRegisterIntegrationEvent",
                EventData = new UserRegisterIntegrationEvent()
                {
                    Email = user.Email,
                    UserIp = _identityService.GetUserIp(),
                    FullName = user.FirstName + " " + user.LastName,
                }
            };

            await _mediator.Send(sendNotifyCommand);

            if (!updateSuccess)
            {
                return Response<ResponseDefault>.Success("User must login and change passowrd", new ResponseDefault()
                {
                    Data = "https://auth.omtest.online/auth/realms/reactjs/protocol/openid-connect/auth?client_id=reatjs-app&scope=openid%20profile%20email&redirect_uri=https%3A%2F%2Fomtest.online%2F&response_type=code"
                });
            }
            return Response<ResponseDefault>.Success(user.Id);
        }
    }
}
