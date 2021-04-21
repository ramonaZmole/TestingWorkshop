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


namespace TestingWorkshop.Tests
{
    [TestClass]
    public class BookingTests : BaseTest
    {
        RestClient client = RequestHelper.GetRestClient("https://automationintesting.online/");
        int roomId;

        [TestInitialize]
        public override void TestInitialize()
        {
            client.AddDefaultHeader("cookie", "__cfduid=da238cb8c831b6c8851619a317d638e571616569469; _ga=GA1.2.289307235.1616569470; _gid=GA1.2.1338565523.1616569470; banner=true; token=4UzjLD4mJGFgy1E1; _gat=1");
            var response = client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
            roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(response.Content).roomId;
            base.TestInitialize();
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

        [TestCleanup]
        public void TestCleanUp()
        {
            client.CreateRequest($"{ApiResource.Room}/{roomId}", Method.DELETE);
        }
    }
}
