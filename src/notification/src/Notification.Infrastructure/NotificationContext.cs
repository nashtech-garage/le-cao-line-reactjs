using Notification.Domain.Seedwork;
using Notification.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Notification.Infrastructure
{
    public class NotificationContext : DbContext, IUnitOfWork
    {
        public const string DEFAULT_SCHEMA = "cat"; //journal of economic studies

        private IDbContextTransaction _currentTransaction;

        public NotificationContext(DbContextOptions<NotificationContext> options) : base(options)
        {
            System.Diagnostics.Debug.WriteLine("AccountContext::ctor ->" + this.GetHashCode());
        }

        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        public bool HasActiveTransaction => _currentTransaction != null;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ReplaceService<IHistoryRepository, CustomNpgsqlHistoryRepository>();
            optionsBuilder.UseSnakeCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var result = await base.SaveChangesAsync(cancellationToken);
            return result > 0;
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null)
            {
                System.Diagnostics.Debug.WriteLine("_currentTransaction is not null");
                return null;
            }
            _currentTransaction = await Database.BeginTransactionAsync(IsolationLevel.ReadCommitted);
            if (_currentTransaction == null)
            {
                System.Diagnostics.Debug.WriteLine("_currentTransaction could not begin");
            }
            return _currentTransaction;
        }

        public async Task CommitTransactionAsync(IDbContextTransaction transaction)
        {
            if (transaction == null) throw new ArgumentNullException(nameof(transaction));
            if (transaction != _currentTransaction) throw new InvalidOperationException($"Transaction {transaction.TransactionId} is not current");

            try
            {
                await SaveChangesAsync();
                transaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
    public class AccountContextDesignFactory : IDesignTimeDbContextFactory<NotificationContext>
    {
        public NotificationContext CreateDbContext(string[] args)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Notification.API")) 
                .AddJsonFile("appsettings.json", false, true);

            IConfiguration config = builder.Build();
            var connectionString = config.GetConnectionString("Default");
            var optionsBuilder = new DbContextOptionsBuilder<NotificationContext>()
                .UseNpgsql(connectionString)
                .UseSnakeCaseNamingConvention()
                .ReplaceService<IHistoryRepository, CustomNpgsqlHistoryRepository>();

            return new NotificationContext(optionsBuilder.Options);
        }
    }
}