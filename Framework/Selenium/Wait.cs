using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public class Wait
    {
        private readonly WebDriverWait _wait;

        public Wait(int waitSecond)
        {
            _wait = new WebDriverWait(Driver.Current, TimeSpan.FromSeconds(waitSecond))
            {
                PollingInterval = TimeSpan.FromMilliseconds(500)
            };

            _wait.IgnoreExceptionTypes
                (
                typeof(NoSuchElementException),
                typeof(ElementNotVisibleException),
                typeof(StaleElementReferenceException)
                ); 
        }

        public bool Until(Func<IWebDriver, bool> condition)
        {
            return _wait.Until(condition);
        }
    }
}
