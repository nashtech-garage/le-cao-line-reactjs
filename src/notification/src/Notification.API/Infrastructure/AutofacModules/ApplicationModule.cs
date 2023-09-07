using Autofac;
using Notification.API.Infrastructure.Services;
using EventBus.Abstractions;
using System.Reflection;
using Notification.Infrastructure.Repositories;
using Notification.API.Application.Commands;

namespace Notification.API.Infrastructure.AutofacModules
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
            builder.RegisterType<EmailService>()
              .As<IEmailService>()
              .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(SendMailCommandHandler).GetTypeInfo().Assembly)
            .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}
