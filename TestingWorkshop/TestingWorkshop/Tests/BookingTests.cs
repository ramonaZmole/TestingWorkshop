using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using OfficeOpenXml.Packaging.Ionic.Zip;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;


namespace TestingWorkshop.Tests
{
    [TestClass]
    public class BookingTests : BaseTest
    {
        RestClient client = RequestHelper.GetRestClient(Constants.Url);
        int roomId;

        [TestInitialize]
        public override void TestInitialize()
        {
            client.AddDefaultHeader("cookie", Constants.Cookie);
            var response = client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
            roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(response.Content).roomId;
            base.TestInitialize();
        }

        [TestMethod]
        public void WhenBookingRoomSuccessMessageShouldBeDisplayedTest()
        {
            Pages.HomePage.ClickBookThisRoomButton();
            Pages.HomePage.CompleteBookingDetails(new UserModel());
            Pages.HomePage.ClickBookRoom();
            Pages.HomePage.IsSuccesfullBooking().Should().BeTrue();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            client.CreateRequest($"{ApiResource.Room}/{roomId}", Method.DELETE);
        }
    }
}
