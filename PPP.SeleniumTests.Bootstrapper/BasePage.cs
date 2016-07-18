using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace PPP.SeleniumTests.Bootstrapper
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public BasePage(IWebDriver webDriver)
        {
            driver = webDriver;
            PageFactory.InitElements(driver, this);
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }

        public void openPage(string url)
        {
            driver.Url = url;
            driver.Manage().Window.Maximize();
        }

        protected void SwitchToFrame(By by)
        {
            driver.WaitUntilElementIsPresent(by, 10);
            driver.SwitchTo().Frame(driver.FindElement(by));
        }
    }
}