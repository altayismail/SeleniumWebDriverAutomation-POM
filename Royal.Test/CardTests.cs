using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using Royal.Pages;

namespace Royal.Test
{
    public class CardTests
    {
        [SetUp]
        public void BeforeEach()
        {
            Driver.Init();
            Pages.Pages.Init();
            Driver.GoTo("https://statsroyale.com");
        }

        [TearDown]
        public void AfterEach()
        {
            Driver.Current.Quit();
        }

        [Test]
        public void Given_Card_is_on_Card_Page()
        {
            var iceSpirit = Pages.Pages.Cards.Goto().GetCardByName("Ice Spirit");
            Assert.That(iceSpirit.Displayed);
        }

        static string[] cardNames = { "Ice Spirit", "Barbarians" };

        [Test]
        [TestCaseSource("cardNames")]
        [Parallelizable(ParallelScope.Children)]
        public void Give_Card_Headers_are_Correct_on_Cards_Detail_Page(string cardName)
        {
            Pages.Pages.Cards.Goto().GetCardByName(cardName).Click();

            var cardOnPage = Pages.Pages.CardDetails.GetBaseCard();
            var card = new InMemoryCardService().GetCardByName(cardName);

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}