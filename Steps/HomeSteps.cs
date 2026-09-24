using NUnit.Framework;
using Reqnroll;





[Binding]
public class HomeSteps
{
    private readonly HomePage homePage;
    private readonly TestSettings testSettings;

    public HomeSteps(TestSettings testSettings)
    {
        this.testSettings = testSettings;
        homePage = new HomePage(TestHooks.Driver);
    }


    [When("the user clicks the View button for the first product")]
    public void WhenTheUserClicksTheViewButtonForTheFirstProduct()
    {
        homePage.ClickProductDetails();
    }


    [When("the user navigates to the Product Details page")]
    public void WhenTheUserNavigatesToTheProductDetailsPage()
    {
        Assert.That(
            homePage.IsDisplayedProductDetailsPage(),
            Is.True);
    }


    [When("the user clicks the Home button")]
    public void WhenTheUserClicksTheHomeButton()
    {
        homePage.ClickHomeButton();
    }


    [When("the user clicks the Orders button")]
    public void WhenTheUserClicksTheOrdersButton()
    {
        homePage.ClickOrders();
    }


    [When("the user navigates to the Order Details page")]
    public void WhenTheUserNavigatesToTheOrderDetailsPage()
    {
        Assert.That(
            homePage.IsDisplayedOrderDetailsPage(),
            Is.True);
    }


    [When("the user clicks the Go Back to Shop button")]
    public void WhenTheUserClicksTheGoBackToShopButton()
    {
        homePage.ClickHomeButton();
    }


    [Given("the user is on the Home page")]
    public void GivenTheUserIsOnTheHomePage()
    {
        Assert.That(
            homePage.IsDisplayedHomePage(),
            Is.True);
    }


    [When("the user clicks the Cart button")]
    public void WhenTheUserClicksTheCartButton()
    {
        homePage.ClickCart();
    }


    [When("the user navigates to the My Cart page")]
    public void WhenTheUserNavigatesToTheMyCartPage()
    {
        Assert.That(
            homePage.IsDisplayedCartDetailsPage(),
            Is.True);
    }


    [When("the user clicks the Continue Shopping button")]
    public void WhenTheUserClicksTheContinueShoppingButton()
    {
        homePage.ClickShoppingButton();
    }
}