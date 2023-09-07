using EventBus.Abstractions;
using MediatR;
using Notification.API.Application.Commands;
using Notification.API.Application.IntegrationEvents.Events;
using System.Text;

namespace Notification.API.Application.IntegrationEvents.EventHandling
{
    public class UserResetPasswordIntegrationEventHandler : IIntegrationEventHandler<UserResetPasswordIntegrationEvent>
    {
        private readonly IMediator _mediator;
        public UserResetPasswordIntegrationEventHandler(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task Handle(UserResetPasswordIntegrationEvent @event)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<h1>Xin chào {@event.FullName}</h1>");
            sb.AppendLine($"<p>Bạn vừa thay đổi mật khẩu trên hệ thống ReactJS Team tại địa chỉ IP: {@event.UserIp}. Vui lòng thông báo cho quản trị viên biết nếu đây không phải là bạn.</p>");
            sb.AppendLine($"<p>Xin cảm ơn.</p>");

            var sendMailCommand = new SendMailCommand()
            {
                Email = @event.Email,
                Body = sb.ToString(),
                Subject = "Thông báo thay đổi mật khẩu truy cập ReactJS Team"
            };

            await _mediator.Send(sendMailCommand);

            await Task.CompletedTask;
        }
    }
}
