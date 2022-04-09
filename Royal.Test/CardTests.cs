using Framework;
using Framework.Model;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using Royal.Test.Base;
using System.Collections.Generic;

namespace Royal.Test
{
    public class CardTests : TestBase
    {
        static IList<Card> apiCards = new ApiCardService().GetAllCards();

        [Test, Category("Cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Given_Card_is_on_Card_Page(Card card)
        {
            var cardName = Pages.Pages.Cards.Goto().GetCardByName(card.Name);
            Assert.That(cardName.Displayed);
        }

        [Test, Category("Cards")]
        [TestCaseSource("apiCards")]
        [Parallelizable(ParallelScope.Children)]
        public void Give_Card_Headers_are_Correct_on_Cards_Detail_Page(Card card)
        {
            Pages.Pages.Cards.Goto().GetCardByName(card.Name).Click();
            var cardOnPage = Pages.Pages.CardDetails.GetBaseCard();

            Assert.AreEqual(card.Name, cardOnPage.Name);
            Assert.AreEqual(card.Type, cardOnPage.Type);
            Assert.AreEqual(card.Arena, cardOnPage.Arena);
            Assert.AreEqual(card.Rarity, cardOnPage.Rarity);
        }
    }
}