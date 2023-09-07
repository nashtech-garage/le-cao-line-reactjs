using FluentValidation;
using Notification.API.Application.Commands;

namespace Notification.API.Application.Validations
{
    public class SendMailCommandValidator : AbstractValidator<SendMailCommand>
    {
        public SendMailCommandValidator()
        {

        }
    }
}
