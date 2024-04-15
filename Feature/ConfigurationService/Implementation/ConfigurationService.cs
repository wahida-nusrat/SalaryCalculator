using Microsoft.Extensions.Configuration;
using RegistrationService.Interfaces;
using Config = SalaryCalculator.Foundation.Configuration;
namespace RegistrationService.Implementation
{
    public class ConfigurationService : IConfigurationService
    {
        public IConfiguration GetAppSettingConfiguration()
        {
            return Config.Configuration.AppSettingConfiguration();
        }
    }
}
