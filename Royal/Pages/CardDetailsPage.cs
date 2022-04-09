using Framework.Model;
using Framework.Selenium;
using OpenQA.Selenium;

namespace Royal.Pages
{
    public class CardDetailsPage : PageBase
    {
        public readonly CardDetailsPageMap Map;

        public CardDetailsPage()
        {
            Map = new CardDetailsPageMap();
        }

        public (string Category, string Arena) GetCardCategory()
        {
            var categories = Map.CardCategories.Text.Split(", ");
            return (categories[0].Trim(), categories[1].Trim());
        }

        public Card GetBaseCard()
        {
            var (category, arena) = GetCardCategory();

            return new Card
            {
                Name = Map.CardName.Text,
                Rarity = Map.CardRarity.Text,
                Type = category,
                Arena = arena
            };
        }
    }

    public class CardDetailsPageMap
    {
        public Element CardName => Driver.FindElement(By.CssSelector("[class*='card__cardName']"), "Card Name");

        public Element CardCategories => Driver.FindElement(By.CssSelector("div[class*='card__rarity']"), "Card Category");

        public Element CardRarity => Driver.FindElement(By.CssSelector("div[class*='card__common']"), "Card Rarity");
    }
}
