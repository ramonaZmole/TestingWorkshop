using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;

namespace TestingWorkshop.Helpers
{
    public class BaseTest : NsTestFrameworkUI.BaseTest
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            Browser.InitializeDriver();
            Browser.GoTo(Constants.Url);

        }
    }
}
