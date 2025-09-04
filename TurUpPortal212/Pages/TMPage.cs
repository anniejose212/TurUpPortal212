using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TurUpPortal212.Pages
{
    public class TMPage
    {
        private readonly IWebDriver driver;
        private readonly WebDriverWait wait;

        public TMPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }
        public void NavigateToTMPage()
        {
            // Administration tab
            var adminTab = By.CssSelector("li > a.dropdown-toggle[data-toggle='dropdown']");
            wait.Until(ExpectedConditions.ElementToBeClickable(adminTab)).Click();

            // Time & Materials menu
            var tmMenu = By.CssSelector("ul.dropdown-menu a[href*='/TimeMaterial']");
            wait.Until(ExpectedConditions.ElementToBeClickable(tmMenu)).Click();
        }


        public void CreateTimeRecord()

        {

            if (!driver.Url.Contains("/TimeMaterial"))
            {
                NavigateToTMPage();
                wait.Until(d => d.Url.Contains("/TimeMaterial"));
            }
            // Click Create New
            var createNewButton = driver.FindElement(By.XPath("//a[normalize-space()='Create New']"));
            wait.Until(ExpectedConditions.ElementToBeClickable(createNewButton)).Click();


            // Select Time from dropdown
            var typeDropdown = By.CssSelector("span.k-dropdown-wrap .k-select");
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(typeDropdown))
                .Click();

       
            var timeOption = By.XPath("//ul[@id='TypeCode_listbox']/li[normalize-space()='Time']");
            new WebDriverWait(driver, TimeSpan.FromSeconds(5))
                .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(timeOption))
                .Click();

            // Fill Code
            var codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TASK129");

            // Fill Description
            var descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Automation Test Description");

            // Fill Price
            var priceTextbox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("100");

            // Save
            var saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
        }

        public void EditTimeRecord(string code, string newDescription)
        {

            //Go to last page
            var lastPageBtn = driver.FindElement(By.CssSelector("a.k-link.k-pager-nav.k-pager-last[title='Go to the last page']"));
            lastPageBtn.Click();

            // Find the row by code
            var lastRowCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]/td[@role='gridcell']"));
            string codeText = lastRowCode.Text;

            lastRowCode.Click();

            // Click Edit (first link in the last cell)
            var lastRowEdit = driver.FindElement(By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]//a[@class='k-button k-button-icontext k-grid-Edit']"));
            lastRowEdit.Click();

            // Clear and update description
            var descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys(newDescription);

            // Save
            var saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
        }

        public void DeleteTimeRecord(string code)
        {
            // Find the row by code
            var lastPageBtn = driver.FindElement(By.CssSelector("a.k-link.k-pager-nav.k-pager-last[title='Go to the last page']"));
            lastPageBtn.Click();

            // Find the row by code
            var lastRowCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']//table/tbody/tr[last()]/td[@role='gridcell']"));
            string codeText = lastRowCode.Text;

            // Click Delete (second link in the last cell)
            var lastRowDelete = driver.FindElement(By.CssSelector("#tmsGrid table tbody tr:last-child a.k-button.k-button-icontext.k-grid-Delete"));
            lastRowDelete.Click();

            // Handle confirmation alert
            driver.SwitchTo().Alert().Accept();
        }
    }
}
