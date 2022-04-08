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
            Driver.Wait.Until(drvr => Map.CopiedMessage.Displayed);
            return this;
        }

        public CopyDeckPage ClickNoButton()
        {
            Map.NoButton.Click();
            Driver.Wait.Until(drvr => Map.CopiedMessage.Displayed);
            return this;
        }

        public void OpenAppStore()
        {
            Map.AppStoreIcon.Click();
            Driver.Wait.Until(drvr => Map.AppStoreIcon.Displayed);
        }

        public void OpenGooglePlay()
        {
            Map.GooglePlayIcon.Click();
            Driver.Wait.Until(drvr => Map.GooglePlayIcon.Displayed);
        }

    }

    public class CopyDeckPageMap
    {
        public IWebElement YesButton => Driver.FindElement(By.ClassName("copyButton"));
        public IWebElement NoButton => Driver.FindElement(By.Id("not-installed"));
        public IWebElement CopiedMessage => Driver.FindElement(By.Id("button-open"));
        public IWebElement GooglePlayIcon => Driver.FindElement(By.XPath("//a[contains(text(),'Google Play')]"));
        public IWebElement AppStoreIcon => Driver.FindElement(By.XPath("//a[contains(text(),'App Store')]"));
    }
}
