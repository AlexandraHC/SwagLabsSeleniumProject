namespace SwagLabsSeleniumProject.Pages;

public class ProductsPage
{
    private IWebDriver _driver;

    public ProductsPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement ProductsDisplayed => _driver.FindElement(By.XPath("//*[@data-test='title']"));
    public IWebElement DropdownBurgerMenu => _driver.FindElement(By.Id("react-burger-menu-btn"));
    public IWebElement ProductName => _driver.FindElement(By.LinkText("Sauce Labs Backpack"));
    public IWebElement ShoppingCartLink => _driver.FindElement(By.ClassName("shopping_cart_link"));
    public IWebElement AddToCartBtn_Onesie => _driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
    public IWebElement ItemInCartItemsList => _driver.FindElement(By.XPath("//*[@data-test='inventory-item-name']"));
    public IWebElement FilterProductsDropdown => _driver.FindElement(By.XPath("//*[@data-test='product-sort-container']"));
    public IWebElement LinkedInFooterLink => _driver.FindElement(By.XPath("//*[@id=\"page_wrapper\"]/footer/ul/li[3]/a"));
    public IWebElement ActiveOption => _driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/div/span/span"));

    public bool IsOnProducts()
    {
        return ProductsDisplayed.Displayed;
    }

    public void ClickOnAProduct()
    {
        ProductName.Click();
    }

    public void AddToCartAnItem()
    {
        AddToCartBtn_Onesie.Click();
    }
}
