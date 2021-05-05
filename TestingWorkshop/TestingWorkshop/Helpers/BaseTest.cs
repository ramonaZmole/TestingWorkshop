using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;

namespace TestingWorkshop.Helpers
{
    public class BaseTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public virtual void TestInitialize()
        {

            Browser.InitializeDriver(true);
            Browser.GoTo(Constants.Url);
        }

        [TestCleanup]
        public virtual void TestCleanUp()
        {
            if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
            {
                var path = ScreenShot.GetScreenShotPath(TestContext.TestName);
                TestContext.AddResultFile(path);
            }
            Browser.Cleanup();
        }
    }
}
