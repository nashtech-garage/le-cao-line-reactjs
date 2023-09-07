using Account.API.Application.Commands;
using Account.API.Infrastructure.ResponseGeneric;
using FluentValidation;

namespace Account.API.Application.Validations
{
    public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
    {
        public RegisterUserCommandValidator()
        {
            RuleFor(x => x.Username).MinimumLength(6).WithMessage(ErrorCode.InvalidMinLength);
            RuleFor(x => x.Password).MinimumLength(8).WithMessage(ErrorCode.InvalidMinLength);
            RuleFor(x => x.VerifyPassword).MinimumLength(8).WithMessage(ErrorCode.InvalidMinLength);
            RuleFor(x => x.LastName).MinimumLength(3).WithMessage(ErrorCode.InvalidMinLength);
            RuleFor(x => x.FirstName).MinimumLength(3).WithMessage(ErrorCode.InvalidMinLength);

            RuleFor(x => x.Username).MaximumLength(255).WithMessage(ErrorCode.InvalidMaxLength);
            RuleFor(x => x.Password).MaximumLength(255).WithMessage(ErrorCode.InvalidMaxLength);
            RuleFor(x => x.VerifyPassword).MaximumLength(255).WithMessage(ErrorCode.InvalidMaxLength);
            RuleFor(x => x.LastName).MaximumLength(255).WithMessage(ErrorCode.InvalidMaxLength);
            RuleFor(x => x.FirstName).MaximumLength(255).WithMessage(ErrorCode.InvalidMaxLength);

            RuleFor(x => x.VerifyPassword)
            .Equal(y => y.Password).WithMessage(ErrorCode.InvalidVerifyPassword);

            RuleFor(x => x.Username)
            .Matches(@"^[a-zA-Z0-9]+$").WithMessage(ErrorCode.InvalidUsernameFormat);

            RuleFor(x => x.Email)
            .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
            .WithMessage(ErrorCode.InvalidUsernameFormat);
        }
    }
}
