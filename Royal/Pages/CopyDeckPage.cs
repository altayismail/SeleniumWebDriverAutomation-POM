using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;
        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public void ClickYesButton()
        {
            Map.YesButton.Click();
        }

    }

    public class CopyDeckPageMap
    {
        public IWebElement YesButton => Driver.FindElement(By.ClassName("copyButton"));
        public IWebElement CopiedMessage => Driver.FindElement(By.Id("button-open"));
    }
}
