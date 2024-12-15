using SwagLabsSeleniumProject.Pages;
using SwagLabsSeleniumProject.Tests.Common;

namespace SwagLabsSeleniumProject.Tests;

public class ProductsPageTests : TestBase
{
    [SetUp]
    public new void Setup()
    {
        base.Setup();

        LoginPage login = new LoginPage(_driver);
        login.Login("standard_user", "secret_sauce");
        login.LoginBtn.Submit();
    }

    [Test]
    public void SortDescendingPriceFromDropdown()
    {
        ProductsPage productsPage = new ProductsPage(_driver);
        productsPage.IsOnProducts();

        SelectElement selectElement = new SelectElement(productsPage.FilterProductsDropdown);
        selectElement.SelectByText("Price (high to low)");
        Assert.IsTrue(productsPage.IsOnProducts());
        Assert.IsTrue(productsPage.ActiveOption.Text == "Price (high to low)");
    }

    [Test]
    public void MultiselectOptionFromDropdown()
    {
        ProductsPage productsPage = new ProductsPage(_driver);
        productsPage.IsOnProducts();

        SelectElement selectElement = new SelectElement(productsPage.FilterProductsDropdown);
        selectElement.SelectByValue("az");
        selectElement.SelectByValue("za");
        Assert.IsTrue(productsPage.IsOnProducts());
        Assert.IsTrue(productsPage.ActiveOption.Text == "Name (Z to A)");
    }

    [Test]
    public void AddToCartFromProductsPage()
    {
        ProductsPage productsPage = new ProductsPage(_driver);
        productsPage.IsOnProducts();

        productsPage.AddToCartAnItem();
        productsPage.ShoppingCartLink.Click();
        Assert.IsTrue(productsPage.ItemInCartItemsList.Displayed);  
    }

    [Test]
    public void SocialMediaLinkOnProductDetails()
    {
        ProductsPage productsPage = new ProductsPage(_driver);
        productsPage.IsOnProducts();
        productsPage.LinkedInFooterLink.Click();   
    }
}
