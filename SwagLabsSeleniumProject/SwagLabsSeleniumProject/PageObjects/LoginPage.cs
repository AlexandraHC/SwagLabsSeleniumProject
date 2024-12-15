namespace SwagLabsSeleniumProject.Pages;

public class LoginPage
{
    private IWebDriver _driver;

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
    }

    public IWebElement TxtUserName => _driver.FindElement(By.Id("user-name"));
    public IWebElement TxtPassword => _driver.FindElement(By.Id("password"));
    public IWebElement LoginBtn => _driver.FindElement(By.Name("login-button"));
    public IWebElement ProductsDisplayed => _driver.FindElement(By.XPath("//*[@data-test='title']"));
    public IWebElement DropdownBurgerMenu => _driver.FindElement(By.Id("react-burger-menu-btn"));
    public IWebElement LogoutLink => _driver.FindElement(By.Id("logout_sidebar_link"));
    public By ValidationErrorElement => By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3");

    public void Login(string username, string password)
    {
        TxtUserName.SendKeys(username);
        TxtPassword.SendKeys(password);
    }

    public bool IsLoggedIn()
    {
        return ProductsDisplayed.Displayed;
    }

    //logout user from dropdown (burger menu)
    public bool IsLoggedOut()
    {
        return TxtUserName.Displayed;
    }
}
