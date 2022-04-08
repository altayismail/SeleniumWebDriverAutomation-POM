using Framework;
using Framework.Selenium;
using NUnit.Framework;


namespace Royal.Test
{
    public class CopyDeskTests
    {
        [OneTimeSetUp]
        public void BeforeAll()
        {
            FW.CreateTestResultsDirectory();
        }
        [SetUp]
        public void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Pages.Init();
            Driver.GoTo("https://statsroyale.com");
        }
        [TearDown]
        public void AfterEach()
        {
            Driver.Quit();
        }

        [Test, Category("copyDeck")]
        public void User_can_copy_the_Deck()
        {
            Pages.Pages.DeckBuilder.Goto().AddCardManually();
            Pages.Pages.DeckBuilder.CopySuggestedDeck();
            Pages.Pages.CopyDeck.ClickYesButton();

            Assert.That(Pages.Pages.CopyDeck.Map.CopiedMessage.Displayed);
        }

        [Test, Category("copyDeck")]
        public void User_Opens_App_Store()
        {
            Pages.Pages.DeckBuilder.Goto().AddCardManually();
            Pages.Pages.DeckBuilder.CopySuggestedDeck();
            Pages.Pages.CopyDeck.ClickNoButton().OpenAppStore();
            Assert.AreEqual(Driver.Title, Is.EqualTo("Clash Royale on the App Store"));
        }

        [Test, Category("copyDeck")]
        public void User_Opens_Google_Play()
        {
            Pages.Pages.DeckBuilder.Goto().AddCardManually();
            Pages.Pages.DeckBuilder.CopySuggestedDeck();
            Pages.Pages.CopyDeck.ClickNoButton().OpenGooglePlay();
            Assert.AreEqual(Driver.Title, Is.EqualTo("Clash Royale - Apps on Google Play"));
        }
    }
}
