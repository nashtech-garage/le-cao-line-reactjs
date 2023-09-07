using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Domain.AggregatesModel.ExamAggregate
{
    public interface IExamRepository : IRepository<Exam>
    {
        IQueryable<Exam> Exams { get; }
        IQueryable<Schedule> Schedules { get; }
        IQueryable<ExamResult> ExamResults { get; }
        IQueryable<QuestionAnswer> QuestionAnswers { get; }

        void Add<T>(T entity) where T : Entity;
        void AddRange<T>(IEnumerable<T> entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
    }
}
