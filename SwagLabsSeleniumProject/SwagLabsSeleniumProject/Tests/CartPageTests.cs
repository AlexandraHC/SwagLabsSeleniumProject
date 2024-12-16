using SwagLabsSeleniumProject.Driver;
using SwagLabsSeleniumProject.Pages;
using SwagLabsSeleniumProject.Tests.Common;

namespace SwagLabsSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
public class CartPageTests : TestBase
{
    public CartPageTests(DriverType driverType) : base(driverType)
    {
  
    }

    [SetUp]
    public new void Setup()
    {
        base.Setup();
        LoginPage login = new LoginPage(_driver);
        login.Login("standard_user", "secret_sauce");
        login.LoginBtn.Submit();
    }

    [Test]
    public void AddToCartButonTest()
    {
        CartPage addToCartPage = new CartPage(_driver);

        WebDriverWait waitElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement _addToCart = waitElement.Until(driver =>
        {
            return addToCartPage.AddItemBtn_BikeLight;
        });
        Assert.IsNotNull(_addToCart);
        waitElement.IgnoreExceptionTypes(typeof(NoSuchElementException));

        _addToCart.Click();

        // "Remove" button is visible instead of "AddToCart" button
        Assert.IsTrue(addToCartPage.RemoveItemBtn_BikeLight.Displayed);

        addToCartPage.ShoppingCartLink.Click();

        // the added product is in the cart products list
        Assert.IsTrue(addToCartPage.BikeLightItemInCartItemsList.Displayed);
    }

    [Test]
    public void RemoveFromCartTest()
    {
        CartPage addToCartPage = new CartPage(_driver);

        WebDriverWait waitElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement addToCartElement = waitElement.Until(driver =>
        {
            return addToCartPage.AddItemBtn_BikeLight;
        });
        Assert.IsNotNull(addToCartElement);
        waitElement.IgnoreExceptionTypes(typeof(NoSuchElementException));

        // add product to cart
        addToCartElement.Click();

        // check if the "Remove" button is visible instead of "AddToCart" button
        Assert.IsTrue(addToCartPage.RemoveItemBtn_BikeLight.Displayed);

        // remove product from cart
        addToCartPage.RemoveFromCartButtonClick();

        // check if the "AddToCart" button is visible instead of "Remove" button
        Assert.IsTrue(addToCartPage.AddItemBtn_BikeLight.Displayed);
    }
}
