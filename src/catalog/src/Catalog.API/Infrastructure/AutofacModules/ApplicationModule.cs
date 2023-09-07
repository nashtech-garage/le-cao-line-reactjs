using Autofac;
using Catalog.API.Application.Commands;
using Catalog.API.Infrastructure.Services;
using Catalog.Domain.AggregatesModel.ExamAggregate;
using Catalog.Domain.AggregatesModel.QuestionAggregate;
using Catalog.Infrastructure.Repositories;
using EventBus.Abstractions;
using System.Reflection;

namespace Catalog.API.Infrastructure.AutofacModules
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

            builder.RegisterType<QuestionRepository>()
                .As<IQuestionRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ExamRepository>()
                .As<IExamRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(CreateCommandHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IIntegrationEventHandler<>));
        }
    }
}