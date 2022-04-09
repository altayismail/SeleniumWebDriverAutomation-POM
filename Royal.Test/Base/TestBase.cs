using Framework;
using Framework.Selenium;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace Royal.Test.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void BeforeAll()
        {
            FW.SetConfig();
            FW.CreateTestResultsDirectory();
        }
        [SetUp]
        public virtual void BeforeEach()
        {
            FW.SetLogger();
            Driver.Init();
            Pages.Pages.Init();
            Driver.GoTo(FW.Config.Test.Url);
        }
        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;

            if(outcome == TestStatus.Passed)
            {
                FW.Log.Info("Outcome: Passed");
            }
            else if(outcome == TestStatus.Failed)
            {
                Driver.TakeScreenShot("test_failed");
                FW.Log.Info("Outcome: Failed");
            }
            else
            {
                FW.Log.Info("Outcome: " + outcome);
            }
            Driver.Quit();
        }
    }
}
