using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;
using Xunit.Abstractions;

namespace XunitSeleniumTests
{

    public class UnitTests
    {
        [Fact]
        public void Everything_Is_OK()
        {
            Assert.True(1 == 1);
        }

        [Fact]
        public void OPS()
        {
            Assert.False(0 == 1);
        }
    }

    public class SeleniumTests : IDisposable
    {
        private readonly RemoteWebDriver _driver;
        private readonly ITestOutputHelper _output;

        public SeleniumTests(ITestOutputHelper output)
        {
            _output = output;
            var capability = DesiredCapabilities.Edge();
            _driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
            //_driver = new EdgeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void SeleniumTest()
        {
            _driver.Url = "http://www.google.com";
            _driver.Navigate();

            IWebElement element = _driver.FindElement(By.Name("q"));
            element.SendKeys("Cheese!");
            element.Submit();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>(d => d.FindElement(By.Id("resultStats")));

            Assert.Contains("Cheese", _driver.Title);

            _output.WriteLine(_driver.Title);
        }
    }
}