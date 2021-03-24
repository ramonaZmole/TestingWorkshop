using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Browser.GoTo("https://automationintesting.online/#/");

        }


    }
}
