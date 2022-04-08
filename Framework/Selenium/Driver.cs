﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Framework.Selenium
{
    public static class Driver
    {
        [ThreadStatic]
        private static IWebDriver _driver;

        public static void Init()
        {
            _driver = new ChromeDriver(@"C:\Users\Ismail ALTAY\source\repos\Framework\_driver");
        }

        public static void GoTo(string url)
        {
            if (!url.StartsWith("http"))
                url = $"http://{url}";

            Debug.WriteLine(url);
            Current.Navigate().GoToUrl(url);
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null");

        public static IWebElement FindElement(By by)
        {
            return Current.FindElement(by);
        }

        public static IList<IWebElement> FindElements(By by)
        {
            return Current.FindElements(by);
        }
    }
}
