using Autofac;
using Account.API.Infrastructure.Services;
using EventBus.Abstractions;
using System.Reflection;
using Account.Domain.AggregatesModel;
using Account.Infrastructure.Repositories;
using Account.API.Application.Commands;

namespace Account.API.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        public string _connectionString { get; } = null!;

        public ApplicationModule(string connectionString)
        {
            _connectionString = connectionString;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new SqlQueries(_connectionString))
                .As<ISqlQueries>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UserRepository>()
                .As<IUserRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<KeycloakService>()
               .As<IKeycloakService>();

            builder.RegisterAssemblyTypes(typeof(RegisterUserCommandHandler).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
