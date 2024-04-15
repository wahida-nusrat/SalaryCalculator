using Microsoft.Extensions.Configuration;

namespace SalaryCalculator.Foundation.Configuration
{
    public static class Configuration
    {
        public static IConfiguration AppSettingConfiguration()
        {
            // build configuration to get data from config file
            IConfiguration configuration = new ConfigurationBuilder()
                                            .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                                            .AddJsonFile("appsettings.json")
                                            .Build();

            return configuration;
        }
    }
}
