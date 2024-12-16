﻿using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using SwagLabsSeleniumProject.Driver;
using SwagLabsSeleniumProject.Utils;
using SwagLabsSeleniumProject.Utils.Common;

namespace SwagLabsSeleniumProject.Tests.Common
{
    
    public class TestBase
    {
        protected IWebDriver _driver;
        private readonly DriverType _driverType;
        protected Browser Browser { get; private set; }

        public TestBase(DriverType driverType)
        {
            _driverType = driverType;   
        }
        public void Setup()
        {
            ExtentReporting.CreateTest(TestContext.CurrentContext.Test.MethodName + " on " + _driverType.ToString());
            //_driver = new ChromeDriver();
            _driver = GetDriverType(_driverType);
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            _driver.Manage().Window.Maximize();

            Browser = new Browser(_driver);
        }

        //method to get the DriverType
        private IWebDriver GetDriverType(DriverType driverType)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("--headless=new");

            return driverType switch
            {
                DriverType.Chrome => new ChromeDriver(),
                DriverType.Firefox => new FirefoxDriver(),
                DriverType.Edge => new EdgeDriver(),
                _ => _driver
            };
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
