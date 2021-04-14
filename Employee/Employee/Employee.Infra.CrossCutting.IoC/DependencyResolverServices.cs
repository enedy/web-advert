using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Employee.Core.Communication.Mediator;
using Employee.Core.Messages.Notifications;
using Employee.Core.Messages.Notifications.Mediator;
using Employee.Data.Contexts;
using Employee.Data.Repository.Oracle;
using Employee.Data.Repository.SqlServer;
using Employee.Domain.Commands;
using Employee.Domain.Queries;
using Employee.Domain.Repository;

namespace Employee.Infra.CrossCutting.IoC
{
    public static class DependencyResolverServices
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyResolverServices));

            services.AddScoped(provider =>
            {
                var environmentVariables = new EnvironmentVariables();
                var optionsBuilder = new DbContextOptionsBuilder<OracleContext>();
                optionsBuilder.UseOracle(environmentVariables.OracleConnectionString, options => options.UseOracleSQLCompatibility("11"));
                return new OracleContext(optionsBuilder.Options);
            });

            services.AddScoped(provider =>
            {
                var environmentVariables = new EnvironmentVariables();
                var optionsBuilder = new DbContextOptionsBuilder<SqlServerContext>();
                optionsBuilder.UseSqlServer(environmentVariables.SqlServerConnectionString);
                return new SqlServerContext(optionsBuilder.Options);
            });

            // REPOSITORIO
            services.AddScoped<ISynchronizationRepository, SynchronizationRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            // Mediator
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            // Notifications
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Comandos
            services.AddScoped<IRequestHandler<AddEmployeeCommand, bool>, AddEmployeeCommandHandler>();

            // QUERIES
            services.AddScoped<ISynchronizationQueries, SynchronizationQueries>();
        }
    }
}
