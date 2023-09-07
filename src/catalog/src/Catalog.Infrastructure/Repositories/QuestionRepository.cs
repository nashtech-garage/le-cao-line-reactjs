using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Constants;
using Catalog.Domain.DtoModel;
using Catalog.Domain.Seedwork;

namespace Catalog.Infrastructure.Repositories
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly CatalogContext _context;

        public QuestionRepository(CatalogContext context)
        {
            _context = context;
        }

        public IQueryable<Question> Questions => _context.Questions;

        public IQueryable<Domain.AggregatesModel.QuestionAggregate.QuestionType> QuestionTypes => _context.QuestionTypes;

        public IQueryable<Answer> Answers => _context.Answers;
        public IQueryable<Level> Levels => _context.Levels;
        public IQueryable<Tag> Tags => _context.Tags;

        public IUnitOfWork UnitOfWork => _context;

        public void Add<T>(T entity) where T : Entity
        {
            _context.Set<T>().Add(entity);
        }

        public void AddRange<T>(IEnumerable<T> entities) where T : Entity
        {
            _context.Set<T>().AddRange(entities);
        }

        public void Delete<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Update<T>(T entity) where T : Entity
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
    }
}