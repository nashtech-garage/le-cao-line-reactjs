using System;
using System.Collections.Generic;

namespace Quiz.Application.Persistence
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task<TEntity> GetById(string id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(string id, TEntity obj);
        Task Remove(string id);
    }
}
