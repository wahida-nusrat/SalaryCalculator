using Microsoft.Extensions.Configuration;

namespace SalaryCalculator.Feature.Configuration.Interfaces
{
    public interface IConfigurationService
    {
        IConfiguration GetAppSettingConfiguration();
    }
}
