using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using Xunit;
using Xunit.Abstractions;

using PPP.SeleniumTests.Bootstrapper.Tests;

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

    public class SeleniumTests : BaseSeleniumTest
    {
        private readonly ITestOutputHelper _output;

        public SeleniumTests(ITestOutputHelper output)
        {
            _output = output;
            //var capability = DesiredCapabilities.Edge();
            //_driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), capability);
            //webDriver = new ChromeDriver();
        }

        [Fact]
        public void SeleniumTest()
        {
            webDriver.Url = rootUrl;            

            IWebElement element = webDriver.FindElement(By.Name("q"));
            element.SendKeys("Cat!");
            element.Submit();
            
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));
            var myDynamicElement = wait.Until(d => d.FindElement(By.Id("resultStats")));
            
            Assert.Contains("Cat", webDriver.Title);

            PickScreenShootAsJPG("SeleniumTest1");

            _output.WriteLine(webDriver.Title);
        }
    }
}