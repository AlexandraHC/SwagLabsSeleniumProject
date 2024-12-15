using NUnit.Framework.Interfaces;
using SwagLabsSeleniumProject.Utils;
using SwagLabsSeleniumProject.Utils.Common;

namespace SwagLabsSeleniumProject.Tests.Common
{
    public class TestBase
    {
        protected IWebDriver _driver;
        protected Browser Browser { get; private set; }

        public void Setup()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName);
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _driver.Manage().Window.Maximize();

            Browser = new Browser(_driver);
        }

        [TearDown]
        public void TearDown()
        {
            EndTest();
            ExtentReporting.EndReporting();

            _driver.Quit();
            _driver.Dispose();           
        }

        public void EndTest()
        {
            var testStatus = TestContext.CurrentContext.Result.Outcome.Status;
            var message = TestContext.CurrentContext.Result.Message;

            switch (testStatus)
            {
                case TestStatus.Failed:
                    ExtentReporting.LogFail($"Test has failed {message}");
                    break;
                case TestStatus.Skipped:
                    ExtentReporting.LogInfo($"Test skipped {message}");
                    break;
                case TestStatus.Passed:
                    ExtentReporting.LogPass($"Test passed {message}");
                    break;
                default:
                    break;
            }

            ExtentReporting.LogScreenshot("Ending test", Browser.GetScreenshot());
        }
    }
}
