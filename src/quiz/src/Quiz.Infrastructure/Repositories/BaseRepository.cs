

using MongoDB.Driver;
using Quiz.Application.Persistence;
using Quiz.Infrastructure.Data;

namespace Quiz.Infrastructure.Repositories
{
    public  class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly QuizDbContext _context;

        protected IMongoCollection<TEntity> _dbSet;

        protected BaseRepository(QuizDbContext context)
        {
            _context = context;
            _dbSet = _context.GetCollection<TEntity>();
        }

        public virtual Task Add(TEntity obj)
        {
             _dbSet.InsertOneAsync(obj);
            return Task.CompletedTask;
        }

        public virtual async Task<TEntity> GetById(string id)
        {
            return await _dbSet.Find(Builders<TEntity>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
             return await _dbSet.Find(Builders<TEntity>.Filter.Empty).ToListAsync();
        }

        public virtual Task Update(string id, TEntity obj)
        {
             _dbSet.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", id), obj);
            return Task.CompletedTask;
        }

        public virtual Task Remove(string id)
        {
           _dbSet.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id));
            return Task.CompletedTask;
        }

    }
}
