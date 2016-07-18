using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;

namespace PPP.SeleniumTests.Bootstrapper
{
    public static class DriverExtensions
    {

        public static bool WaitUntilElementIsDisplayed(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by).Displayed);
            }
            return false;
        }

        public static bool WaitUntilElementsAreDisplayed(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElements(by).First().Displayed);
            }
            return false;
        }


        public static bool WaitUntilElementIsPresent(this IWebDriver driver, By by, int timeout = 10)
        {
            for (var i = 0; i < timeout; i++)
            {
                if (driver.ElementIsPresent(by)) return true;
                Thread.Sleep(1000);
            }
            return false;
        }

        public static bool WaitUntilElementsArePresent(this IWebDriver driver, By by, int timeout = 10)
        {
            for (var i = 0; i < timeout; i++)
            {
                if (driver.ElementsArePresent(by)) return true;
                Thread.Sleep(1000);
            }
            return false;
        }

        public static bool ElementIsPresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElement(by).Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool ElementsArePresent(this IWebDriver driver, By by)
        {
            try
            {
                return driver.FindElements(by).First().Displayed;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}