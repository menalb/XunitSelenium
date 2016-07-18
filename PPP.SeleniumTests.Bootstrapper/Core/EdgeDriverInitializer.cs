using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Remote;
using System;

namespace PPP.SeleniumTests.Bootstrapper.Core
{
    class EdgeDriverInitializer : IWebDriverInitializer
    {
        public IWebDriver GetRemotwWebDriver(Uri remoteWebDriverServer)
        {
            return new RemoteWebDriver(remoteWebDriverServer, DesiredCapabilities.Edge());
        }

        public IWebDriver GetWebDriver()
        {
            return new EdgeDriver();
        }

        public IWebDriver GetWebDriver(string driverPath)
        {
            return new EdgeDriver(driverPath);
        }
    }
}