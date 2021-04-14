using Microsoft.Extensions.DependencyInjection;
using System;

namespace Employee.Infra.CrossCutting.IoC
{
    public class DependencyResolver
    {
        public IServiceProvider ServiceProvider { get; }
        public Action<IServiceCollection> RegisterServices { get; }

        public DependencyResolver(Action<IServiceCollection> registerServices = null)
        {
            // Set up Dependency Injection
            var serviceCollection = new ServiceCollection();

            RegisterServices = registerServices;
            ConfigureServices(serviceCollection);
            ServiceProvider = serviceCollection.BuildServiceProvider();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            DependencyResolverServices.RegisterServices(services);

            // Register other services
            RegisterServices?.Invoke(services);
        }
    }
}
