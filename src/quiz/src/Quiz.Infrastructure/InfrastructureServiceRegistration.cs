using Microsoft.Extensions.DependencyInjection;
using Quiz.Application.Persistence;
using Quiz.Infrastructure.Data;
using Quiz.Infrastructure.Repositories;

namespace Quiz.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<QuizDbContext>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IQuizRepository, QuizRepository>();

            return services;
        }
    }
}
