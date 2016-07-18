using System;
using System.Configuration;

namespace PPP.SeleniumTests.Bootstrapper
{
    public class TestsSettings
    {
        public static bool IsRemoteDriver()
        {
            return bool.Parse(ConfigurationManager.AppSettings["isRemote"]);
        }

        public static Uri RemoteDriverServerUrl()
        {
            if (!string.IsNullOrEmpty(ConfigurationManager.AppSettings["remoteWebDriverServerUrl"]))
                return new Uri(ConfigurationManager.AppSettings["remoteWebDriverServerUrl"]);
            return null;
        }

        public static string SeleniumDriverName()
        {
            return ConfigurationManager.AppSettings["seleniumWebDriverName"];
        }

        public static string SeleniumDriverPath()
        {
            return ConfigurationManager.AppSettings["seleniumWebDriverPath"];
        }

        public class WebAppTestSettings
        {
            static WebAppTestSettings()
            {
                RootUrl = ConfigurationManager.AppSettings["webAppRootUrl"];
            }

            public static string RootUrl { get; private set; }
        }

        public class UserTestSettings
        {
            static UserTestSettings()
            {
                LoginUsername = ConfigurationManager.AppSettings["loginUserName"];
                LoginPassword = ConfigurationManager.AppSettings["loginPassword"];
                AdministratorLoginUsername = ConfigurationManager.AppSettings["administratorLoginUserName"];
                AdministratorLoginPassword = ConfigurationManager.AppSettings["administratorLoginPassword"];
            }

            public static string LoginUsername { get; private set; }
            public static string LoginPassword { get; private set; }
            public static string AdministratorLoginUsername { get; private set; }
            public static string AdministratorLoginPassword { get; private set; }
        }
    }
}