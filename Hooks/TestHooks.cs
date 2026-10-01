using Allure.Net.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V151.WebAuthn;

[Binding]
public class TestHooks
{
    private readonly ScenarioContext scenarioContext;

    public static IWebDriver Driver { get; private set; } = null!;



    public TestHooks(ScenarioContext scenarioContext)
    {
        this.scenarioContext = scenarioContext;
    }


    [BeforeScenario]
    public void BeforeScenario()
    {
        var options = new ChromeOptions();

        if (Environment.GetEnvironmentVariable("CI") == "true")
        {
            // GitHub Actions / CI
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--disable-gpu");
            options.AddArgument("--window-size=1920,1080");
        }
        else
        {
            // Local development
            options.AddArgument("--start-maximized");
        }

        Driver = new ChromeDriver(options);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        try
        {
            if (scenarioContext.TestError != null)
            {
                CaptureFailureScreenshot();
            }
        }
        finally
        {
            Driver?.Quit();
            Driver?.Dispose();
        }
    }

    private static void CaptureFailureScreenshot()
    {
        if (Driver is not ITakesScreenshot screenshotDriver)
            return;

        var screenshot = screenshotDriver.GetScreenshot();

        AllureApi.AddAttachment(
            "Failure Screenshot",
            "image/png",
            screenshot.AsByteArray
        );
    }

}