using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using OfficeOpenXml.Packaging.Ionic.Zip;
using TestingWorkshop.Helpers;

namespace TestingWorkshop.Tests
{
    [TestClass]
    public class BookingTests : BaseTest
    {
        [TestMethod]
        public void WhenBookingRoomSuccessMessageShouldBeDisplayedTest()
        {
            WaitHelpers.ExplicitWait();
        }
    }
}
