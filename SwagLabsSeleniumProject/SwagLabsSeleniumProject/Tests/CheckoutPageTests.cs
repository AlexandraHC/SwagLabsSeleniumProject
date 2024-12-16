using SwagLabsSeleniumProject.Driver;
using SwagLabsSeleniumProject.Pages;
using SwagLabsSeleniumProject.Tests.Common;

namespace SwagLabsSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
[TestFixture(DriverType.Edge)]
public class CheckoutPageTests : TestBase
{
    public CheckoutPageTests(DriverType driverType) : base(driverType)
    {
    }

    [SetUp]
    public new void Setup()
    {
        base.Setup();

        LoginPage login = new LoginPage(_driver);
        login.Login("standard_user", "secret_sauce");
        login.LoginBtn.Submit();

        CartPage cartPage = new CartPage(_driver);
        cartPage.AddItemBtn_BikeLight.Click();
        cartPage.ShoppingCartLink.Click();
        cartPage.CheckoutBtn.Click();
    }

    [Test]
    public void CheckoutWithValidPersonalData()
    {
        CheckoutPage checkoutPage = new CheckoutPage(_driver);

        checkoutPage.FillInCustomerPersonalData("Alexandra", "Test", "708050");
        checkoutPage.MoveForwardBtn.Submit();
        Assert.IsTrue(checkoutPage.IsPaymentData());

        checkoutPage.FinishCheckoutBtn.Click();
        Assert.IsTrue(checkoutPage.IsOrderPlaced());
        
        checkoutPage.ReturnOnProductsPage();
        Assert.IsTrue(checkoutPage.IsOnProductPage());
    }

    [Test]
    public void CheckoutWithAllFieldEmpty()
    {
        CheckoutPage checkoutPage = new CheckoutPage(_driver);

        checkoutPage.FillInCustomerPersonalData("", "", "");
        checkoutPage.MoveForwardBtn.Submit();

        Assert.IsTrue(checkoutPage.ErrorMessage.Displayed);
    }

    [Test]
    public void CheckoutWithUnvalidPersonaData()
    {
        CheckoutPage checkoutPage = new CheckoutPage(_driver);

        checkoutPage.FillInCustomerPersonalData("!!", "@@", "$%");
        checkoutPage.MoveForwardBtn.Submit();

        checkoutPage.FinishCheckoutBtn.Click();
        Assert.IsTrue(checkoutPage.IsOrderPlaced());

        checkoutPage.ReturnOnProductsPage();
        Assert.IsTrue(checkoutPage.IsOnProductPage());
    }
}
