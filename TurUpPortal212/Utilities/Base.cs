using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Configuration;
using System.IO;

namespace TurUpPortal212.Utilities
{
    public class Base
    {
        protected IWebDriver driver = default!;
        private IConfiguration _config = default!;
        private string _baseUrl = string.Empty;
        private string _browser = "chrome";

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            var baseDir = AppContext.BaseDirectory;

             _config = new ConfigurationBuilder()
                 .SetBasePath(baseDir)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .Build();

            


            _baseUrl = _config["baseUrl"] ?? throw new InvalidOperationException("Missing baseUrl");
            _browser = (_config["browser"] ?? "chrome").ToLowerInvariant();

        }


        [SetUp]
        public void StartBrowser()
        {
            // Read from appsettings.json
            var browser = (_config["browser"] ?? "chrome").ToLowerInvariant();

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
            driver.Navigate().GoToUrl(_baseUrl);
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
