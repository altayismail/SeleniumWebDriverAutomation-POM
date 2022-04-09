using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace Framework.Selenium
{
    public class DriverFactory
    {
        public static IWebDriver Build(string browserName)
        {
            FW.Log.Info($"Browser: {browserName}");
            switch (browserName)
            {
                case "chrome":
                    return new ChromeDriver(FW.WORKSPACE_DIRECTORY + "_driver");
                case "firefox":
                    return new FirefoxDriver(FW.WORKSPACE_DIRECTORY + "_driver");
                default:
                    throw new ArgumentNullException($"{browserName} is not supported");
            }
        }
    }
}
