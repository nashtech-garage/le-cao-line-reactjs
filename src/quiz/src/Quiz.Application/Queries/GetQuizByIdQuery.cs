
using FluentValidation;
using MediatR;
using Quiz.Application.Persistence;
using QuizModel = Quiz.Domain.Models.Quiz;

namespace Quiz.Application.Queries
{
    public class GetQuizByIdQuery : IRequest<QuizModel>
    {
        public string Id { get; set; }
    }
    public class CreateQuizzCommandValidator : AbstractValidator<GetQuizByIdQuery>
    {
        
    }
    public class GetQuizByIdQueryHandler : IRequestHandler<GetQuizByIdQuery, QuizModel>
    {
        private readonly IQuizRepository _quizRepository;

        public GetQuizByIdQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<QuizModel> Handle(GetQuizByIdQuery request, CancellationToken cancellationToken)
        {
            return await _quizRepository.GetById(request.Id);
        }
    }
}

