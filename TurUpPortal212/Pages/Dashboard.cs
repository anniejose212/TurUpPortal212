using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TurUpPortal212.Pages
{
    public class DashboardPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        // Locators
        private By AdministrationTab => By.CssSelector("a.dropdown-toggle[data-toggle='dropdown']");
        private By TimeAndMaterialMenu => By.XPath("//a[@href='/TimeMaterial' and normalize-space()='Time & Materials']");

        // Action
        public void NavigateToTMPage()
        {
            wait.Until(ExpectedConditions.ElementToBeClickable(AdministrationTab)).Click();
            wait.Until(ExpectedConditions.ElementToBeClickable(TimeAndMaterialMenu)).Click();
        }
    }
}
