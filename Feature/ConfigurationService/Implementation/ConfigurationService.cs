using Microsoft.Extensions.Configuration;
using SalaryCalculator.Feature.Configuration.Interfaces;
using Config = SalaryCalculator.Foundation.Configuration;
namespace SalaryCalculator.Feature.Configuration.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration GetAppSettingConfiguration()
        {
            return Config.Configuration.AppSettingConfiguration();
        }
    }
}
