using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace PPP.SeleniumTests.Bootstrapper.Core
{
    public class ChromeDriverInitializer : IWebDriverInitializer
    {
        public IWebDriver GetRemotwWebDriver(Uri remoteWebDriverServer)
        {
            return new RemoteWebDriver(remoteWebDriverServer, DesiredCapabilities.Chrome());
        }

        public IWebDriver GetWebDriver()
        {
            return new ChromeDriver();
        }

        public IWebDriver GetWebDriver(string driverPath)
        {
            return new ChromeDriver(driverPath);
        }
    }
}