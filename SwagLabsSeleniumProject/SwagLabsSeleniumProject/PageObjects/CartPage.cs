namespace SwagLabsSeleniumProject.Pages;

public class CartPage
{
    private IWebDriver _driver;

    public CartPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement AddItemBtn_Backpack => _driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
    public IWebElement AddItemBtn_BikeLight => _driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
    public IWebElement AddItemBtn_Onesie => _driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
    public IWebElement RemoveItemBtn_BikeLight => _driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
    public IWebElement ShoppingCartLink => _driver.FindElement(By.ClassName("shopping_cart_link"));
    public IWebElement BikeLightItemInCartItemsList => _driver.FindElement(By.XPath("//*[contains(@class, 'inventory_item_name') and text()='Sauce Labs Bike Light']"));
    public IWebElement BackBtn => _driver.FindElement(By.Id("continue-shopping"));
    public IWebElement CheckoutBtn => _driver.FindElement(By.Id("checkout"));

    public void AddToCartButtonClick()
    {
        AddItemBtn_Backpack.Click();
        AddItemBtn_BikeLight.Click();
        AddItemBtn_Onesie.Click();
    }

    public void ShpoppingCartClick()
    {
        ShoppingCartLink.Click();
    }

    //remove the items from the basket
    public void RemoveFromCartButtonClick()
    {
        RemoveItemBtn_BikeLight.Click();
    }
}
