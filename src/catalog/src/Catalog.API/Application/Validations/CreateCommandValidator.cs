using Catalog.API.Application.Commands;
using Catalog.API.Infrastructure.ResponseGeneric;
using FluentValidation;

namespace Catalog.API.Application.Validations
{
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(1).WithErrorCode(ErrorCode.Validator);
        }
    }
}