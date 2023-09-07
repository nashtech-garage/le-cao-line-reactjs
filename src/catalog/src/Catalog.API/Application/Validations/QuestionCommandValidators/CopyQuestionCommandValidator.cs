using Catalog.API.Application.Commands.QuestionCommands.CopyQuestion;
using Catalog.API.Infrastructure.ResponseGeneric;
using FluentValidation;

namespace Catalog.API.Application.Validations.QuestionCommandValidators
{
    public class CopyQuestionCommandValidator : AbstractValidator<CopyQuestionCommand>
    {
        public CopyQuestionCommandValidator()
        {
            RuleFor(x => x.QuestionId).NotEmpty().WithErrorCode(ErrorCode.DataEmpty);
        }
    }
}