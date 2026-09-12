using Microsoft.Extensions.Configuration;

public static class TestSettingsProvider
{
    public static TestSettings Load()
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .Build();

        var settings = configuration
            .GetSection("TestSettings")
            .Get<TestSettings>();

        if (settings == null)
        {
            throw new Exception(
                "TestSettings section could not be loaded from appsettings.json");
        }

        return settings;
    }
}