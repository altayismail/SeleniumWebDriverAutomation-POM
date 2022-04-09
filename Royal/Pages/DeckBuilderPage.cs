using Framework;
using Framework.Selenium;
using OpenQA.Selenium;

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
            FW.Log.Step("Click Deck Builder link");
            headerNav.Map.DeckBuilderLink.Click();
            Driver.Wait.Until(WaitConditions.ElementDisplayed(Map.AddCardsManuallyLink));
            return this;
        }

        public void AddCardManually()
        {
            Driver.Wait.Until(WaitConditions.ElementIsDisplayed(Map.AddCardsManuallyLink)).Click();
            FW.Log.Step("Click Add Cards Manually link");
            Driver.Wait.Until(WaitConditions.ElementIsDisplayed(Map.CopyDeckIcon));
        }

        public void CopySuggestedDeck()
        {
            FW.Log.Step("Click Copy Deck Icon");
            Map.CopyDeckIcon.Click();
        }
    }

    public class DeckBuilderPageMap
    {
        public Element AddCardsManuallyLink => Driver.FindElement(By.CssSelector("a[href='/deckbuilder']"), "Add Cards Manually Link");
        public Element CopyDeckIcon => Driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div/div/div[2]/form/div[3]/a"), "Copy Deck Icon");
    }
}
