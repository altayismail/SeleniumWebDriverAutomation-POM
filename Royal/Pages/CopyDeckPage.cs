using Framework.Selenium;
using OpenQA.Selenium;

namespace Royal.Pages
{
    public class CopyDeckPage
    {
        public readonly CopyDeckPageMap Map;
        public CopyDeckPage()
        {
            Map = new CopyDeckPageMap();
        }

        public CopyDeckPage ClickYesButton()
        {
            Map.YesButton.Click();
            Driver.Wait.Until(WaitConditions.ElementIsDisplayed(Map.CopiedMessage));
            return this;
        }

        public CopyDeckPage ClickNoButton()
        {
            Driver.Wait.Until(WaitConditions.ElementIsDisplayed(Map.NoButton));
            Map.NoButton.Click();
            return this;
        }

        public void OpenAppStore()
        {
            Map.AppStoreIcon.Click();
            Driver.Wait.Until(WaitConditions.ElementIsDisplayed(Map.AppStoreIcon));
        }

        public void OpenGooglePlay()
        {
            Map.GooglePlayIcon.Click();
            Driver.Wait.Until(WaitConditions.ElementDisplayed(Map.GooglePlayIcon));
        }

    }

    public class CopyDeckPageMap
    {
        public Element YesButton => Driver.FindElement(By.ClassName("copyButton"), "Yes Button");
        public Element NoButton => Driver.FindElement(By.Id("not-installed"), "No Button");
        public Element CopiedMessage => Driver.FindElement(By.Id("button-open"), "Copied Message");
        public Element GooglePlayIcon => Driver.FindElement(By.XPath("//a[contains(text(),'Google Play')]"), "Google Play Icon");
        public Element AppStoreIcon => Driver.FindElement(By.XPath("//a[contains(text(),'App Store')]"), "App Store Icon");
    }
}
