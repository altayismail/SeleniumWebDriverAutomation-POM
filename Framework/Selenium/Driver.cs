using OpenQA.Selenium;
using System;
using System.IO;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;
        [ThreadStatic]
        public static Wait Wait;
        [ThreadStatic]
        public static Window Window;

        public static void Init()
        {
            _driver = DriverFactory.Build(FW.Config.Driver.Browser);
            Wait = new Wait(FW.Config.Driver.Wait);
            Window = new Window();
            Window.Maximize();
        }

        public static void GoTo(string url)
        {
            if (!url.StartsWith("http"))
                url = $"http://{url}";

            FW.Log.Info(url);
            Current.Navigate().GoToUrl(url);
        }

        public static void TakeScreenShot(string imageName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(FW.CurrentTestDirectory.FullName, imageName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        public static void Quit()
        {
            FW.Log.Info("Close Browser");
            Current.Quit();
            Current.Dispose();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");
        public static string Title => Current.Title; 

        public static Element FindElement(By by, string name)
        {
            return new Element(Current.FindElement(by), name)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by)
        {
            return new Elements(Current.FindElements(by))
            {
                FoundBy = by
            };
        }
    }
}
