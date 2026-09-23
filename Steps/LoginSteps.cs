using Reqnroll;

[Binding]
public class LoginSteps
{
    private readonly LoginPage loginPage;
    private readonly TestSettings testSettings;

    public LoginSteps(TestSettings testSettings)
    {
        this.testSettings = TestSettingsProvider.Load();
        loginPage = new LoginPage(TestHooks.Driver);
    }

    [Given("user is navigates to login screen")]
    public void UserIsNavigatesToLoginScreen()
    {
        TestHooks.Driver
            .Navigate()
            .GoToUrl(testSettings.Url);
    }

    [When("user is enters 'username'")]
    public void UserIsEntersUsername()
    {
        loginPage.EnterUsername(testSettings.Username);
    }

    [When("user is enters 'password'")]
    public void UserIsEntersPassword()
    {
        loginPage.EnterPassword(testSettings.Password);
    }

    [When("user is clicks login button")]
    public void UserIsClicksLoginButton()
    {
        loginPage.ClickLogin();
    }

    [Then("user is navigate to home page")]
    public void UserIsNavigateToHomePage()
    {
        Assert.That(loginPage.GetTitle(), Is.EqualTo("Let's Shop"));
        Console.WriteLine("!!!!!!! Homepage loaded sucessfully !!!!!!!!!");
    }
}