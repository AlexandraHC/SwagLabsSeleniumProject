using SeleniumExtras.WaitHelpers;
using SwagLabsSeleniumProject.Pages;
using SwagLabsSeleniumProject.Tests.Common;

namespace SwagLabsSeleniumProject.Tests;

public class LoginPageTest : TestBase
{
    [SetUp]
    public new void Setup()
    {
        base.Setup();
    }

    [Test]
    public void LoginTestWithValidCredentials()
    {
        LoginPage login = new LoginPage(_driver);
        login.Login("standard_user", "secret_sauce");
        login.LoginBtn.Submit();

        Assert.IsTrue(login.IsLoggedIn());
    }

    [Test]
    public void LoginTestWithPasswordFieldEmpty()
    {
        LoginPage login = new LoginPage(_driver);
        login.Login("standard_user", "");
        login.LoginBtn.Submit();

        var errorElement = _driver.FindElement(login.ValidationErrorElement);
        Assert.IsTrue(errorElement.Displayed);
    }

    [Test]
    public void LoginTestWithUserFieldEmpty()
    {
        LoginPage login = new LoginPage(_driver);
        login.Login("", "secret_sauce");
        login.LoginBtn.Submit();

        var errorElement = _driver.FindElement(login.ValidationErrorElement);
        Assert.IsTrue(errorElement.Displayed);
    }

    [Test]
    public void LoginTestWithBothFieldsEmpty()
    {
        LoginPage login = new LoginPage(_driver);
        login.Login("", "");
        login.LoginBtn.Submit();

        var errorElement = _driver.FindElement(login.ValidationErrorElement);
        Assert.IsTrue(errorElement.Displayed);
    }

    [Test]
    public void LoginTestWithUnvalidCredentials()
    {
        LoginPage login = new LoginPage(_driver);
        login.Login("test", "@@@");
        login.LoginBtn.Submit();

        var errorElement = _driver.FindElement(login.ValidationErrorElement);
        Assert.True(errorElement.Displayed, "Epic sadface: Username and password do not match any user in this service");
    }

    [Test]
    public void LoginTestWithLocketOutUser()
    {
        LoginPage login = new LoginPage(_driver);
        login.Login("locked_out_user", "secret_sauce");
        login.LoginBtn.Submit();

        var errorElement = _driver.FindElement(login.ValidationErrorElement);
        Assert.True(errorElement.Displayed, "Epic sadface: Sorry, this user has been locked out.");
    }

    [Test]
    public void LogoutTest() 
    {
        LoginPage login = new LoginPage(_driver);
        login.Login("standard_user", "secret_sauce");
        login.LoginBtn.Submit();

        login.DropdownBurgerMenu.Click();

        WebDriverWait waitElement = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        IWebElement logoutLink = waitElement.Until(ExpectedConditions.ElementToBeClickable(By.Id("logout_sidebar_link")));

        logoutLink.Click();
        Assert.IsTrue(login.IsLoggedOut());
    }
}
