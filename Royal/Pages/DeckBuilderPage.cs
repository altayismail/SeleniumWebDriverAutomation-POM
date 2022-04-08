using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Royal.Pages
{
    public class DeckBuilderPage : PageBase
    {
        public readonly DeckBuilderPageMap Map;
        public DeckBuilderPage()
        {
            Map = new DeckBuilderPageMap();
        }
        public DeckBuilderPage Goto()
        {
            headerNav.Map.DeckBuilderLink.Click();
            return this;
        }

        public void AddCardManually()
        {
            Map.AddCardsManuallyLink.Click();
        }

        public void CopySuggestedDeck()
        {
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public IWebElement AddCardsManuallyLink => Driver.FindElement(By.CssSelector("a[href=/deckbuilder]"));
        public IWebElement CopyDeckIcon => Driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div/div/div[2]/form/div[3]/a"));
    }
}
