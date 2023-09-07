using FluentValidation;
using MediatR;
using Quiz.Application.Persistence;
using QuizModel = Quiz.Domain.Models.Quiz;

namespace Quiz.Application.Queries
{
    public class GetAllQuizzesQuery : IRequest<List<QuizModel>>
    {
       
    }
    public class GetAllQuizzesQueryValidator : AbstractValidator<GetAllQuizzesQuery>
    {

    }
    public class GetAllQuizzesQueryHandler : IRequestHandler<GetAllQuizzesQuery, List<QuizModel>>
    {
        private readonly IQuizRepository _quizRepository;

        public GetAllQuizzesQueryHandler(IQuizRepository quizRepository)
        {
            _quizRepository = quizRepository;
        }
        public async Task<List<QuizModel>> Handle(GetAllQuizzesQuery request, CancellationToken cancellationToken)
        {
            return (await _quizRepository.GetAll()).ToList();
        }
    }
}

