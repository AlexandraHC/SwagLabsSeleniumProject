namespace SwagLabsSeleniumProject.Pages;

public class ProductDetailsPage
{
    private IWebDriver _driver;

    public ProductDetailsPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement ProductName => _driver.FindElement(By.XPath("//*[@data-test='inventory-item-name']"));
    public IWebElement ProductDescription => _driver.FindElement(By.XPath("//*[@data-test='inventory-item-desc']"));
    public IWebElement ProductPrice => _driver.FindElement(By.ClassName("inventory_details_price"));
    public IWebElement AddToCartBtn_Backpack => _driver.FindElement(By.Id("add-to-cart"));
    public IWebElement BackToProductsLnk => _driver.FindElement(By.Id("back-to-products"));
    public IWebElement ShoppingCartLink => _driver.FindElement(By.ClassName("shopping_cart_link"));
    public IWebElement BackpackItemInCartItemsList => _driver.FindElement(By.XPath("//*[@id=\"item_4_title_link\"]/div"));
    public IWebElement ProductsDisplayed => _driver.FindElement(By.XPath("//*[@data-test='title']"));
    public IWebElement FacebookFooterLink => _driver.FindElement(By.XPath("//*[@id=\"page_wrapper\"]/footer/ul/li[2]/a"));

    public bool IsOnProducts()
    {
        return ProductsDisplayed.Displayed;
    }

    public void ClickOnAProduct()
    {
        ProductName.Click();
    }

    public bool IsOnProductDetails()
    {
        return ProductName.Displayed;
    }

    public void GoToProducts()
    {
        BackToProductsLnk.Click();
    }


    public void AddToCartButton()
    {
        AddToCartBtn_Backpack.Click();   
    }
}
