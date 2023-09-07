using Account.Domain.AggregatesModel;
using Account.Domain.Seedwork;

namespace Account.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AccountContext _context;

        public UserRepository(AccountContext context)
        {
            _context = context;
        }

        public IQueryable<User> Users => _context.Users;
        public IQueryable<Role> Roles => _context.Roles;
        public IQueryable<UserRole> UserRoles => _context.UserRoles;

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
