using Account.API.Application.IntegrationEvents.Events;
using Account.API.Infrastructure.ResponseGeneric;
using Account.API.Infrastructure.Services;
using Account.API.Models;
using Account.Domain.AggregatesModel;
using Account.Domain.Exceptions;
using MediatR;
using static Account.API.Models.KeyCloakApi;

namespace Account.API.Application.Commands
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Response<ResponseDefault>>
    {
        private readonly IMediator _mediator;
        private readonly IIdentityService _identityService;
        private readonly IKeycloakAdminService _keycloakAdminService;
        private readonly IKeycloakService _keycloakService;

        public ChangePasswordCommandHandler(IIdentityService identityService, IKeycloakAdminService keycloakAdminService, IMediator mediator, IKeycloakService keycloakService)
        {
            _identityService = identityService;
            _keycloakAdminService = keycloakAdminService;
            _mediator = mediator;
            _keycloakService = keycloakService;
        }

        public async Task<Response<ResponseDefault>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var user = _identityService.GetIdentityUser();

            var token = await _keycloakService.UserLogin(user.Username, request.CurrentPassword);
            if (token is null)
            {
                return Response<ResponseDefault>.Fail("Current password is wrong!");
            }

            var body = new CredentialRepresentation()
            {
                Temporary = false,
                Type = "password",
                Value = request.Password,
            };

            var updateSuccess = await _keycloakAdminService.ResetPassword(user.UserId, body);

            if (updateSuccess)
            {
                // send notification
                var sendNotifyCommand = new SendNotifiyCommand()
                {
                    EventId = "UserResetPasswordIntegrationEvent",
                    EventData = new UserResetPasswordIntegrationEvent()
                    {
                        Email = user.Email,
                        UserIp = _identityService.GetUserIp(),
                        FullName = user.Name,
                    }
                };

                await _mediator.Send(sendNotifyCommand);

                return Response<ResponseDefault>.Success("Change password is successful");
            }

            return Response<ResponseDefault>.Fail(user.UserId);
        }
    }
}
