using Account.Domain.Seedwork;

namespace Account.Domain.AggregatesModel
{
    public interface IUserRepository : IRepository<User>
    {
        IQueryable<User> Users { get; }
        IQueryable<Role> Roles { get; }
        IQueryable<UserRole> UserRoles { get; }

        void Add<T>(T entity) where T : Entity;
        void AddRange<T>(IEnumerable<T> entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
    }
}
