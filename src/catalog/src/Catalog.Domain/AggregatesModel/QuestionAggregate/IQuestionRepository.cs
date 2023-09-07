using Catalog.Domain.DtoModel;
using Catalog.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain.Seedwork;

namespace Catalog.Domain.AggregatesModel.QuestionAggregate
{
    public interface IQuestionRepository : IRepository<Question>
    {
        IQueryable<Question> Questions { get; }
        IQueryable<QuestionType> QuestionTypes { get; }
        IQueryable<Answer> Answers { get; }
        IQueryable<Level> Levels { get; }
        IQueryable<Tag> Tags { get; }

        void Add<T>(T entity) where T : Entity;
        void AddRange<T>(IEnumerable<T> entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
    }
}