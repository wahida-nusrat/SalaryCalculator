using Microsoft.Extensions.Configuration;

namespace RegistrationService.Interfaces
{
    public interface IConfigurationService
    {
        IConfiguration GetAppSettingConfiguration();
    }
}
