using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace AutomationTests
{
    public class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
        }

        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public void ClickElement(By byLocator)
        {
            var element = Wait.Until(driver =>
            {
                var foundElement = driver.FindElement(byLocator);
                if (foundElement != null && foundElement.Displayed && foundElement.Enabled)
                {
                    return foundElement;
                }
                return null;
            });
            element.Click();
        }

        public void EnterText(By byLocator, string text)
        {
            var element = Wait.Until(driver =>
            {
                var foundElement = driver.FindElement(byLocator);
                if (foundElement != null && foundElement.Displayed && foundElement.Enabled)
                {
                    return foundElement;
                }
                return null;
            });
            element.Clear();
            element.SendKeys(text);
        }

    }
}
