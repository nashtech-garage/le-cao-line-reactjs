using Catalog.API.Application.Commands.QuestionCommands;
using Catalog.API.Infrastructure.ResponseGeneric;
using FluentValidation;

namespace Catalog.API.Application.Validations.QuestionCommandValidators
{
    public class UpdateQuestionCommandValidator : AbstractValidator<UpdateQuestionCommand>
    {
        public UpdateQuestionCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithErrorCode(ErrorCode.DataEmpty);
            RuleFor(x => x.QuestionContent).NotEmpty().WithErrorCode(ErrorCode.DataEmpty);
            RuleFor(x => x.Answers).NotEmpty().WithErrorCode(ErrorCode.DataEmpty);
            RuleFor(x => x.Answers).Must(list => list.Where(x => x.AnswerValue == "true").Count() >= 1)
                .WithErrorCode(ErrorCode.Validator);
            RuleFor(x => x.Answers).Must(list => !list.Where(x => string.IsNullOrEmpty(x.AnswerContent)).Any())
                .WithErrorCode(ErrorCode.DataEmpty);
        }
    }
}