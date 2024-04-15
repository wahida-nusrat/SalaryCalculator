// for assembly infor and configure logging file as assembly.cs is not avaiable after .net 6
using log4net.Core;
[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]

namespace Logging
{
    public static class LoggingConfigure
    {
        public static void Configure() {
           log4net.Config.XmlConfigurator.Configure();
        }
    }
}
