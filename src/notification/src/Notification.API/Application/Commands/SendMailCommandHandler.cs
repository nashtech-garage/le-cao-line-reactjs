using MediatR;
using Notification.API.Infrastructure.ResponseGeneric;
using Notification.API.Infrastructure.Services;

namespace Notification.API.Application.Commands
{
    public class SendMailCommandHandler : IRequestHandler<SendMailCommand, Response<ResponseDefault>>
    {
        private readonly IEmailService _emailService;
        public SendMailCommandHandler(IEmailService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        public async Task<Response<ResponseDefault>> Handle(SendMailCommand request, CancellationToken cancellationToken)
        {
            await _emailService.SendAsync(request.Email, request.Subject, request.Body);

            return Response<ResponseDefault>.Success();
        }
    }
}
