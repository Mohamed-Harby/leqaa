using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Tests.IntegrationTests;
public class ConfigurationInitializer
{
    public static IConfiguration InitializeConfiguration()
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.tests.json")
        .AddEnvironmentVariables()
        .Build();
        return configuration;
    }
}