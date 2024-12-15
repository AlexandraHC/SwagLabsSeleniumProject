using SeleniumExtras.WaitHelpers;

namespace SwagLabsSeleniumProject.Tests;

public class NUnitTests
{
    private IWebDriver _driver;

    // only once at the beggining of the testing session
    [OneTimeSetUp]
    public void InitialSetup()
    {
        
    }

    // before each test
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        _driver.Manage().Window.Maximize();
    }

    [Test]
    public void LoginTest()
    {
        IWebElement userElement = _driver.FindElement(By.Id("user-name"));
        userElement.SendKeys("standard_user");

        IWebElement passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys("secret_sauce");

        IWebElement btnLogin = _driver.FindElement(By.Name("login-button"));
        btnLogin.Submit();

        IWebElement productsTitle = _driver.FindElement(By.XPath("//*[@data-test='title']"));
        Assert.True(productsTitle.Displayed, "Products title is displayed");
    }

    [Test]
    public void AddToCartButtonTest()
    {
        IWebElement userElement = _driver.FindElement(By.Id("user-name"));
        userElement.SendKeys("standard_user");

        IWebElement passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys("secret_sauce");

        IWebElement btnLogin = _driver.FindElement(By.Name("login-button"));
        btnLogin.Submit();

        WebDriverWait waitElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement _addToCart = waitElement.Until(ExpectedConditions.ElementIsVisible(By.Id("add-to-cart-sauce-labs-bike-light")));
        waitElement.IgnoreExceptionTypes(typeof(NoSuchElementException));
        _addToCart.Click();

        IWebElement cartElement = _driver.FindElement(By.ClassName("shopping_cart_link"));
        cartElement.Click();

        IWebElement checkoutElement = _driver.FindElement(By.Id("checkout"));
        checkoutElement.Click();
    }

    [Test]
    public void CheckoutTestPage()
    {
        IWebElement userElement = _driver.FindElement(By.Id("user-name"));
        userElement.SendKeys("standard_user");

        IWebElement passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys("secret_sauce");

        IWebElement btnLogin = _driver.FindElement(By.Name("login-button"));
        btnLogin.Submit();

        WebDriverWait waitElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement _addToCart = waitElement.Until(ExpectedConditions.ElementIsVisible(By.Id("add-to-cart-sauce-labs-bike-light")));
        waitElement.IgnoreExceptionTypes(typeof(NoSuchElementException));

        _addToCart.Click();

        IWebElement cartElement = _driver.FindElement(By.ClassName("shopping_cart_link"));
        cartElement.Click();

        IWebElement checkoutElement = _driver.FindElement(By.Id("checkout"));
        checkoutElement.Click();

        _driver.FindElement(By.Id("first-name")).SendKeys("Huruniuc");
        _driver.FindElement(By.Id("last-name")).SendKeys("Alexandra");
        _driver.FindElement(By.Name("postalCode")).SendKeys("707085");

        IWebElement submitBtn = _driver.FindElement(By.Name("continue"));
        submitBtn.Click();

        _driver.FindElement(By.Id("finish")).Click();
    }

    [Test]
    public void FilterSelectDropdownByValue()
    {
        // Login first
        IWebElement userElement = _driver.FindElement(By.Id("user-name"));
        userElement.SendKeys("standard_user");

        IWebElement passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys("secret_sauce");

        IWebElement btnLogin = _driver.FindElement(By.Name("login-button"));
        btnLogin.Submit();

        // Found the dropdown and selected
        SelectElement selectElement = new SelectElement(_driver.FindElement(By.ClassName("product_sort_container")));

        selectElement.SelectByValue("lohi");
    }

    [Test]
    public void LogoutTest()
    {
        // Login first
        IWebElement userElement = _driver.FindElement(By.Id("user-name"));
        userElement.SendKeys("standard_user");

        IWebElement passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys("secret_sauce");

        IWebElement btnLogin = _driver.FindElement(By.Name("login-button"));
        btnLogin.Submit();

        // Click on the burger menu and logout
        _driver.FindElement(By.Id("react-burger-menu-btn")).Click();

        WebDriverWait waitElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement logout = waitElement.Until(ExpectedConditions.ElementIsVisible(By.LinkText("Logout")));
        waitElement.IgnoreExceptionTypes(typeof(NoSuchElementException));
    }

    [Test]
    public void LoginNonExistingUser()
    {
        IWebElement userElement = _driver.FindElement(By.Id("user-name"));
        userElement.SendKeys("wrong-user");

        IWebElement passwordElement = _driver.FindElement(By.Id("password"));
        passwordElement.SendKeys("wrongPassword");

        IWebElement btnLogin = _driver.FindElement(By.Name("login-button"));
        btnLogin.Submit();

        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement errorMessage = wait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("error-message-container")));

        // Assert that error message is displayed
        Assert.IsTrue(errorMessage.Displayed, "Error message is displayed.");
    }

    // after each test
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }

    // once at the final of the testing session
    [OneTimeTearDown]
    public void FinalTearDown()
    {
        
    }
}