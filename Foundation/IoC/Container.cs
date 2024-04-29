using Logging.Implementation;
using Logging.Interface;
using Microsoft.Extensions.DependencyInjection;
using SalaryCalculation.Service;
using SalaryCalculaton.Services.Implementation;
using SalaryCalculaton.Services.Interface;
using Config = SalaryCalculator.Foundation.Configuration;

namespace SalaryCalculator.Foundation.IoC
{
    public static class Container
    {
        public static ServiceProvider Register()
        {
            // create service collecion for DI
            var serviceCollection = new ServiceCollection();

            var configuration = Config.Configuration.AppSettingConfiguration();

            serviceCollection.AddSingleton(configuration);
            serviceCollection.AddSingleton<Ilogger, Logger>();
            serviceCollection.AddSingleton<IIncomeCalculation, IncomeCalculation>();
            serviceCollection.AddTransient<CalculatorService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }

        public static T GetService<T>(ServiceProvider serviceProvider)
        {
            // get specific service provider for any generic class
            var service = serviceProvider.GetRequiredService<T>();
            return service;
        }
    }
}
