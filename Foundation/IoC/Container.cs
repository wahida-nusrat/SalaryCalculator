using Logging.Implementation;
using Logging.Interface;
using Microsoft.Extensions.DependencyInjection;
using RegistrationService.Implementation;
using RegistrationService.Interfaces;

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
            serviceCollection.AddSingleton<ILoggerService, LoggerService>();

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
