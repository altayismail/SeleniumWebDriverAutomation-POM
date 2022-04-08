using Framework.Model;
using Framework.Selenium;
using Framework.Services;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;


namespace Royal.Test
{
    public class CopyDeskTests
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
        public void User_can_copy_the_Deck()
        {
            Pages.Pages.DeckBuilder.Goto();
            Pages.Pages.DeckBuilder.AddCardManually();
            
            Driver.Wait.Until(drvr => Pages.Pages.DeckBuilder.Map.CopyDeckIcon.Displayed);
            Pages.Pages.DeckBuilder.CopySuggestedDeck();
            
            Driver.FindElement(By.Id("button-open")).Click();
            
            Pages.Pages.CopyDeck.ClickYesButton();
            Driver.Wait.Until(drvr => Pages.Pages.CopyDeck.Map.CopiedMessage.Displayed);

            Assert.That(Pages.Pages.CopyDeck.Map.CopiedMessage.Displayed);
        }
    }
}
