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
        private readonly IWebDriver _driver;

        private readonly By usernameField = By.Id("UserName");
        private readonly By passwordField = By.Id("Password");
        private readonly By loginButton = By.XPath(("//input[@type='submit' and @value='Log in']"));
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }


        public void Login(string username, string password)
        {

            _driver.FindElement(usernameField).SendKeys(username);
            _driver.FindElement(passwordField).SendKeys(password);
            _driver.FindElement(loginButton).Click();
        }

    }

    }

