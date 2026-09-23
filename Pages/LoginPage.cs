using OpenQA.Selenium;

public class LoginPage
{
    private readonly IWebDriver driver;

    public LoginPage(IWebDriver driver)
    {
        this.driver = driver;
    }


    private readonly By username = By.Id("userEmail");
    private readonly By password = By.Id("userPassword");
    private readonly By loginButton = By.Id("login");



    public void EnterUsername(String Username)
    {
        driver.FindElement(username).SendKeys(Username);
    }

    public void EnterPassword(String Password)
    {
        driver.FindElement(password).SendKeys(Password);
    }

    public void ClickLogin()
    {
        driver.FindElement(loginButton).Click();
    }

    public String GetTitle()
    {

        String DashboardTitle = driver.Title;

        return DashboardTitle;
    }

}