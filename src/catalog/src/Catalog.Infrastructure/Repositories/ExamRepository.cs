using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Constants;
using Catalog.Domain.DtoModel;
using Catalog.Domain.Seedwork;

namespace Catalog.Infrastructure.Repositories
{
    public class ExamRepository : IExamRepository
    {
        private readonly CatalogContext _context;

        public ExamRepository(CatalogContext context)
        {
            _context = context;
        }

        public IQueryable<Exam> Exams => _context.Exams;
        public IQueryable<Schedule> Schedules => _context.Schedules;
        public IQueryable<ExamResult> ExamResults => _context.ExamResults;
        public IQueryable<QuestionAnswer> QuestionAnswers => _context.QuestionAnswers;

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