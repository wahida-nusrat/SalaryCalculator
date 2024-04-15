using Logging.Implementation;
using Logging.Interface;
using Microsoft.Extensions.DependencyInjection;
using SalaryCalculator.Feature.Configuration.Implementation;
using SalaryCalculator.Feature.Configuration.Interfaces;

namespace SalaryCalculator.Foundation.IoC
{
    public static class Container
    {
        private static IServiceCollection Register()
        {
            // create service collecion for DI
            var serviceCollection = new ServiceCollection();

            // add configuration to service collection
            // in future we can add anyy serice like caching
            serviceCollection.AddSingleton<IConfigurationService, ConfigurationService>();
            serviceCollection.AddSingleton<Ilogger, Logger>();

            return serviceCollection;
        }
        public static T GetServiceProvider<T>()
        {
            var services = Register();
            var serviceProvider = services.BuildServiceProvider();
            // get specific service provider for any generic class
            var configurationService = serviceProvider.GetRequiredService<T>();
            return configurationService;
        }
    }
}
