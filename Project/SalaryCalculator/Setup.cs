using SalaryCalculator.Feature.Configuration.Interfaces;
using SalaryCalculator.Foundation.IoC;
using Microsoft.Extensions.Configuration;
using Logging.Interface;

namespace SalaryCalculator
{
    public static class Setup
    {
        public static IConfiguration ConfigurationSetup()
        {
            var serviceProvider = Container.GetServiceProvider<IConfigurationService>();
            var configuration = serviceProvider.GetAppSettingConfiguration();
            return configuration;
        }

        public static void LoggingSetup()
        {
            var serviceProvider = Container.GetServiceProvider<Ilogger>();
            serviceProvider.Configure();
        }
    }
}
