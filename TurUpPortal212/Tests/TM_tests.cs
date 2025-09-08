using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurUpPortal212.Pages;
using TurUpPortal212.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;

namespace TurUpPortal212.Tests
{

    [TestFixture]
    public class TM_tests: Base
    {

        [SetUp]
        public void SetUpsteps()
        {
            // Create an instance of the LoginPage class
            var loginPageObj = new LoginPage(driver);

            var username = TestContext.Parameters.Get("username", ConfigReader.Configuration["username"]);
            var password = TestContext.Parameters.Get("password", ConfigReader.Configuration["password"]);

            loginPageObj.Login(username, password);

            var helloUser = driver.FindElement(By.XPath($"//a[normalize-space()='Hello {username}!']"));
            Assert.That(helloUser.Displayed, Is.True, $"Login failed - 'Hello {username}!' not visible.");

            var dashboardPageObj = new DashboardPage(driver);
            dashboardPageObj.NavigateToTMPage();

            Assert.That(driver.Url, Does.Contain("/TimeMaterial"));
            TestContext.WriteLine("✅ Verified navigation: URL contains '/TimeMaterial'.");


        }
        

        [Test]
        public void CreateTime_Test()
        {
            // Create an instance of the TMPage class
            var CreateTimeRecordObj = new TMPage(driver);

            // Call the CreateTM method to create a new Time and Material record
            CreateTimeRecordObj.CreateTimeRecord();

            
        }

        [Test]
        public void EditTime_Test()
        {
            var EditTimeRecordObj = new TMPage(driver);
            EditTimeRecordObj.EditTimeRecord( "TASK129", "This is .");
        }
           
        [Test]
        public void DeleteTime_Test()
        {
            var DeleteTimeRecordObj = new TMPage(driver);
            DeleteTimeRecordObj.DeleteTimeRecord("TASK129");
        }



    }
}