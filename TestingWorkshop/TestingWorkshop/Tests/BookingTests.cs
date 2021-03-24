using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using OfficeOpenXml.Packaging.Ionic.Zip;
using RestSharp;
using TestingWorkshop.Helpers;

namespace TestingWorkshop.Tests
{
    [TestClass]
    public class BookingTests : BaseTest
    {
        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var client = RequestHelper.GetRestClient("https://automationintesting.online/");
            var response = client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
        }

        [TestMethod]
        public void WhenBookingRoomSuccessMessageShouldBeDisplayedTest()
        {
            Pages.HomePage.ClickBookThisRoomButton();
            Pages.HomePage.InsertContactData("First Name", "Last Name", "test@g.com", "45815553332");
            Pages.HomePage.SelectDates();
            Pages.HomePage.ClickBookRoom();
            Pages.HomePage.IsSuccesfullBooking().Should().BeTrue();
        }
    }
}
