using Catalog.API.Application.Commands.QuestionCommands;
using Catalog.API.Infrastructure.ResponseGeneric;
using FluentValidation;

namespace Catalog.API.Application.Validations.QuestionCommandValidators
{
    public class GetQuestionByIdCommandValidator : AbstractValidator<GetQuestionByIdCommand>
    {
        public GetQuestionByIdCommandValidator()
        {
            RuleFor(x => x.QuestionId).NotEmpty().WithErrorCode(ErrorCode.DataEmpty);
        }
    }
}