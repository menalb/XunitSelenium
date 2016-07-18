using OpenQA.Selenium;
using System;

namespace PPP.SeleniumTests.Bootstrapper.Tests
{
    public class BaseSeleniumTest : IDisposable
    {
        protected readonly IWebDriver webDriver;
        protected readonly string rootUrl;
        private readonly string _driverName;
        private readonly string _driverPath;
        private readonly string _screenShootPath;

        public BaseSeleniumTest()
        {
            rootUrl = TestsSettings.WebAppTestSettings.RootUrl;
            _driverName = TestsSettings.SeleniumDriverName();
            _driverPath = TestsSettings.SeleniumDriverPath();
            _screenShootPath = TestsSettings.ScreenShootsFolderPath();

            if (TestsSettings.IsRemoteDriver())
                webDriver = new BaseWebDriver().GetRemoteWebDriver(_driverName, TestsSettings.RemoteDriverServerUrl());
            else
                webDriver = new BaseWebDriver().GetWebDriver(_driverName, _driverPath);
        }

        public virtual void PickScreenShootAsJPG(string fileName)
        {
            webDriver.PickScreenShoot($"{_screenShootPath}\\{fileName}.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public void Dispose()
        {
            webDriver.Dispose();
        }
    }
}