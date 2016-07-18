using System;
using OpenQA.Selenium;

using PPP.SeleniumTests.Bootstrapper.Core;

namespace PPP.SeleniumTests.Bootstrapper
{
    public class BaseWebDriver
    {
        private IWebDriver webDriver;

        public IWebDriver GetWebDriver(string webDriverName, string webDriverPath)
        {
            try
            {
                webDriver = GetWebDriverInitializer(webDriverName).GetWebDriver(webDriverPath);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Invalid driver", e);
            }
            catch (Exception)
            {
                throw;
            }

            return webDriver;
        }

        public IWebDriver GetRemoteWebDriver(string webDriverName, Uri remoteWebDriverServer)
        {
            try
            {
                webDriver = GetWebDriverInitializer(webDriverName).GetRemotwWebDriver(remoteWebDriverServer);
            }
            catch (NullReferenceException e)
            {
                throw new Exception("Invalid driver", e);
            }
            catch (Exception)
            {
                throw;
            }

            return webDriver;
        }

        private IWebDriverInitializer GetWebDriverInitializer(string webDriverName)
        {
            var type = Type.GetType($"{typeof(IWebDriverInitializer).Namespace.ToString()}.{webDriverName}Initializer");
            return ((IWebDriverInitializer)Activator.CreateInstance(type));
        }

        public void Teardown(IWebDriver driver)
        {
            driver.Quit();
            driver.Dispose();
        }
    }
}