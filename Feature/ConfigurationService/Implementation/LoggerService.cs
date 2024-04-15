using RegistrationService.Interfaces;
using Logging;
namespace RegistrationService.Implementation
{
    public class LoggerService : ILoggerService
    {
        public void ConfigureLoggingConfiguration()
        {
            LoggingConfigure.Configure();
        }
    }
}
