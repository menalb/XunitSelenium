using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;

namespace PPP.SeleniumTests.Bootstrapper.Core
{
    public class FirefoxDriverInitializer : IWebDriverInitializer
    {
        public IWebDriver GetRemotwWebDriver(Uri remoteWebDriverServer)
        {
            return new RemoteWebDriver(remoteWebDriverServer, DesiredCapabilities.Firefox());
        }

        public IWebDriver GetWebDriver()
        {
            return new FirefoxDriver();
        }

        public IWebDriver GetWebDriver(string driverPath)
        {
            return new FirefoxDriver();
        }
    }
}