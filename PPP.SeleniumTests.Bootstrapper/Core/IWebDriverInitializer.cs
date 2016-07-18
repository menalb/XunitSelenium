using OpenQA.Selenium;
using System;

namespace PPP.SeleniumTests.Bootstrapper.Core
{
    public interface IWebDriverInitializer
    {
        IWebDriver GetWebDriver();
        IWebDriver GetWebDriver(string driverPath);
        IWebDriver GetRemotwWebDriver(Uri remoteWebDriverServer);
    }   
}