

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
    private readonly By loginButton = By.Id("userEmail");



    public void enterUsername(String Username)
    {
        driver.FindElement(username).SendKeys(Username);
    }

    public void enterPassword(String Password)
    {
        driver.FindElement(password).SendKeys(Password);
    }

    public void clickLogin()
    {
        driver.FindElement(loginButton).Click();
    }

    public String getTitle()
    {

        String DashboardTitle = driver.Title;

        return DashboardTitle;
    }

}