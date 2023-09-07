using Quiz.Application.Persistence;
using Quiz.Infrastructure.Data;

namespace Quiz.Infrastructure.Repositories
{
    public class QuizRepository : BaseRepository<Domain.Models.Quiz>, IQuizRepository
    {
        public QuizRepository(QuizDbContext context) : base(context)
        {

        }
    }
}
