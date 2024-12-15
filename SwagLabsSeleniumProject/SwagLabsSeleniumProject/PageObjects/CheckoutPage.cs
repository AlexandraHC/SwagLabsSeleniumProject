namespace SwagLabsSeleniumProject.Pages;

public class CheckoutPage
{
    private IWebDriver _driver;

    public CheckoutPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement CheckoutBtn => _driver.FindElement(By.Id("checkout"));
    public IWebElement HeaderTitle => _driver.FindElement(By.XPath("//*[@id=\"header_container\"]/div[2]/span"));
    public IWebElement TxtFirstName => _driver.FindElement(By.Id("first-name"));
    public IWebElement TxtLastName => _driver.FindElement(By.Id("last-name"));
    public IWebElement TxtPostalCode => _driver.FindElement(By.Id("postal-code"));
    public IWebElement MoveForwardBtn => _driver.FindElement(By.Id("continue"));
    public IWebElement BackBtn => _driver.FindElement(By.Id("cancel"));
    public IWebElement CheckoutPaymentData => _driver.FindElement(By.XPath("//*[@id=\"checkout_summary_container\"]/div/div[2]/div[1]"));
    public IWebElement FinishCheckoutBtn => _driver.FindElement(By.Id("finish"));
    public IWebElement CompleteCheckoutTitle => _driver.FindElement(By.XPath("//*[@data-test='title']"));
    public IWebElement BackHomeBtn => _driver.FindElement(By.Id("back-to-products"));
    public IWebElement ProductsDisplayed => _driver.FindElement(By.XPath("//*[@data-test='title']"));
    public IWebElement ErrorMessage => _driver.FindElement(By.XPath("//*[@id=\"checkout_info_container\"]/div/form/div[1]/div[4]/h3"));

    public void PressCheckoutButton()
    {
        CheckoutBtn.Click();
    }

    public void FillInCustomerPersonalData(string firstName, string lastName, string postalCode)
    {
        TxtFirstName.SendKeys(firstName);
        TxtLastName.SendKeys(lastName);
        TxtPostalCode.SendKeys(postalCode);
    }

    public bool IsPaymentData()
    {
        return CheckoutPaymentData.Displayed;
    }

    public bool IsOrderPlaced()
    {
        return CompleteCheckoutTitle.Displayed;
    }

    public void ReturnOnProductsPage()
    {
        BackHomeBtn.Click();
    }

    public bool IsOnProductPage()
    {
        return ProductsDisplayed.Displayed;
    }
}
