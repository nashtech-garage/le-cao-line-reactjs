using FluentValidation;
using MediatR;
using Quiz.Application.Persistence;

namespace Quiz.Application.Commands
{
    public class CreateQuizCommand : IRequest<bool>
    {
        public string Description { get; set; }
    }
    public class CreateQuizzCommandValidator : AbstractValidator<CreateQuizCommand>
    {
        public CreateQuizzCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty().NotNull();
        }
    }
    public class CreateQuizzCommandHandler : IRequestHandler<CreateQuizCommand, bool>
    {
        private readonly IQuizRepository _quizRepository;
     
        public CreateQuizzCommandHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<bool> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            await _quizRepository.Add(new Domain.Models.Quiz
            {
                Description = request.Description,
            });
            return true;
        }
    }
}
