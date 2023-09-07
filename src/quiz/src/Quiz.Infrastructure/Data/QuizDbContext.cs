using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Quiz.Infrastructure.Data 
{
    public class QuizDbContext : MongoDbBaseContext
    {
        protected override string PrefixTable => "Quiz";

        public QuizDbContext(IOptionsMonitor<MongoDatabaseSettings> settings) : base(settings)
        {
        }
        public IMongoCollection<Domain.Models.Quiz> Quizzes { get { return GetCollection<Domain.Models.Quiz>(); } }

    }

}
