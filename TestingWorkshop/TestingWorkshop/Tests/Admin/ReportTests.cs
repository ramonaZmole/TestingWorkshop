using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestingWorkshop.Helpers;

namespace TestingWorkshop.Tests.Admin
{
    [TestClass]
    public class ReportTests: BaseTest
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

        }

        [TestMethod]
        public void WhenBookingARoomDatePeriodShouldBeDisplayedTest()
        {
            Browser.GoTo(Constants.AdminUrl);

            Pages.LoginPage.Login();
            // //*[contains(text(),'tte iiu tst niui')] 
            Pages.AdminHeaderPage.GoToMenu(Helpers.Model.MenuItems.Report);

        }



    }
}
