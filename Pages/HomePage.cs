using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class HomePage
{
    private readonly IWebDriver driver;
    private readonly WebDriverWait wait;

    public HomePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }

    private readonly By homeButton =
        By.CssSelector("button[routerlink='/dashboard/']");

    private readonly By viewButton =
        By.XPath("(//button[contains(text(), 'View')])[1]");

    private readonly By orderButton =
        By.XPath("//button[contains(text(), 'ORDERS')]");

    private readonly By cartButton =
        By.XPath("//button[@routerlink='/dashboard/cart']");

    private readonly By productDetailsLabel =
        By.XPath("//h6[contains(text(), 'product details')]");

    private readonly By orderDetailsLabel =
        By.XPath("//h1[contains(text(), 'Your Orders')]");

    private readonly By myCartLabel =
        By.XPath("//h1[contains(normalize-space(), 'My Cart')]");

    private readonly By continueShoppingButton =
        By.XPath("//button[contains(normalize-space(), 'Continue Shopping')]");

    private readonly By homeLabel =
        By.CssSelector("section#sidebar");


    public bool IsDisplayedHomePage()
    {
        return wait.Until(driver =>
    driver.FindElement(homeButton).Displayed);
    }

    public bool IsDisplayedProductDetailsPage()
    {
        return wait.Until(driver =>
    driver.FindElement(productDetailsLabel).Displayed);
    }

    public bool IsDisplayedOrderDetailsPage()
    {
        return wait.Until(driver =>
    driver.FindElement(orderDetailsLabel).Displayed);
    }

    public bool IsDisplayedCartDetailsPage()
    {
        return wait.Until(driver =>
    driver.FindElement(myCartLabel).Displayed);
    }


    public void ClickProductDetails()
    {

        wait.Until(driver =>
    driver.FindElement(viewButton).Displayed);

        driver.FindElement(viewButton).Click();
    }

    public void ClickHomeButton()
    {
        driver.FindElement(homeButton).Click();
    }

    public void ClickOrders()
    {
        driver.FindElement(orderButton).Click();
    }

    public void ClickCart()
    {
        driver.FindElement(cartButton).Click();
    }

    public void ClickShoppingButton()
    {
        driver.FindElement(continueShoppingButton).Click();
    }
}