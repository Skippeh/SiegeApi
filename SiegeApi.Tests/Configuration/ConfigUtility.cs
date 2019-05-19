using Microsoft.Extensions.Configuration;

namespace SiegeApi.Tests.Configuration
{
    public static class ConfigUtility
    {
        public static Config GetConfig(string outputPath)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(outputPath)
                .AddJsonFile("appsettings.json", true)
                .AddEnvironmentVariables()
                .Build();

            var result = new Config();
            config.Bind(result);
            return result;
        }
    }
}