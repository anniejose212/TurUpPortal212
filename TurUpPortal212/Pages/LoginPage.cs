using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TurUpPortal212.Pages
{
    public class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        // Identify elements using properties
        private IWebElement UserName => driver.FindElement(By.Id("UserName"));
        private IWebElement Password => driver.FindElement(By.Id("Password"));
        private IWebElement LoginButton => driver.FindElement(By.XPath("//input[@type='submit' and @value='Log in']"));

        public void Login(string username, string password)
        {
            UserName.SendKeys("hari");
            Password.SendKeys("123123");
            LoginButton.Click();
        }

    }

    }

