using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System;
using System.Configuration;

namespace TurUpPortal212.Utilities
{
    public class Base
    {
        protected IWebDriver driver;

        [SetUp]
        public void StartBrowser()
        {
            // Read from App.config
            string browser = ConfigurationManager.AppSettings["browser"]?.ToLower();

            switch (browser)
            {
                case "chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.AddUserProfilePreference("profile.password_manager_leak_detection", false);
                    driver = new ChromeDriver(chromeOptions);
                    break;

                case "firefox":
                    driver = new FirefoxDriver();
                    break;

                case "edge":
                    driver = new EdgeDriver();
                    break;

                default:
                    throw new ArgumentException($"Unsupported browser: {browser}");
            }

            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        }

        [TearDown]
        public void StopBrowser()
        {
            if (driver != null)
            {
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
