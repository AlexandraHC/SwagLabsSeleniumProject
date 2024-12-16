using SwagLabsSeleniumProject.Driver;
using SwagLabsSeleniumProject.Pages;
using SwagLabsSeleniumProject.Tests.Common;

namespace SwagLabsSeleniumProject.Tests;

[TestFixture(DriverType.Firefox)]
[TestFixture(DriverType.Chrome)]
[TestFixture(DriverType.Edge)]
public class ProductDetailsPageTests : TestBase
{
    public ProductDetailsPageTests(DriverType driverType) : base(driverType)
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
    public void AddToCartAProduct()
    {
        ProductDetailsPage productDetails = new ProductDetailsPage(_driver);
        productDetails.IsOnProducts();
        productDetails.ClickOnAProduct();
        Assert.IsTrue(productDetails.ProductName.Displayed);

        productDetails.AddToCartButton();
        productDetails.ShoppingCartLink.Click();
        Assert.IsTrue(productDetails.BackpackItemInCartItemsList.Displayed);
    }

    [Test]
    public void SocialMediaLinkOnProductDetails()
    {
        ProductDetailsPage productDetails = new ProductDetailsPage(_driver);
        productDetails.IsOnProducts();
        productDetails.ClickOnAProduct();
        Assert.IsTrue(productDetails.ProductName.Displayed);

        productDetails.FacebookFooterLink.Click();
    }

    [Test]
    public void ReturnToProductsFromAProduct()
    {
        ProductDetailsPage productDetails = new ProductDetailsPage(_driver);
        productDetails.IsOnProducts();
        productDetails.ClickOnAProduct();

        productDetails.IsOnProductDetails();    
        productDetails.GoToProducts();
        Assert.IsTrue(productDetails.IsOnProducts());
    }
}
