﻿using Framework.Selenium;
using OpenQA.Selenium;

namespace Royal
{
    public class HeaderNav
    {
        public readonly HeaderNavMap Map;
        public HeaderNav()
        {
            Map = new HeaderNavMap();
        }

        public void GotoCardsPage()
        {
            Map.CardsTabLink.Click();
        }
    }

    public class HeaderNavMap
    {
        public IWebElement CardsTabLink => Driver.FindElement(By.CssSelector("a[href='/cards']"));
        public IWebElement DeckBuilderLink => Driver.FindElement(By.CssSelector("a[href=/deckbuilder]"));
    }
}
