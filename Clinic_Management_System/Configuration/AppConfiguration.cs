using Microsoft.Extensions.Configuration;
namespace Clinic_Management_System.Configuration;

internal class AppConfiguration
{
    private readonly IConfigurationRoot _config;

    public AppConfiguration()
    {
        _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
    }

    public string GetConncetionString(string name = "DefaultConnection")
    {
        var connectionString = _config.GetConnectionString(name);
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException($"Connection string '{name}' not found in configuration file.");
        }

        return connectionString;
    }
}
