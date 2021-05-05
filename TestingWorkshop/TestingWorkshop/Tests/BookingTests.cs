using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;
using TestingWorkshop.Helpers.Model.ApiModels;


namespace TestingWorkshop.Tests
{
    [TestClass]
    public class BookingTests : BaseTest
    {
        private readonly RestClient _client = RequestHelper.GetRestClient(Constants.Url);
        private int _roomId;

        [TestInitialize]
        public override void TestInitialize()
        {
            var token = _client.GetLoginToken();
            _client.AddDefaultHeader("cookie", $"token={token}");
            var response = _client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
            _roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(response.Content).roomId;
            base.TestInitialize();
        }

        [TestMethod]
        public void WhenBookingRoomSuccessMessageShouldBeDisplayedTest()
        {
            Pages.HomePage.ClickBookThisRoom();
            Pages.HomePage.CompleteBookingDetails(new UserModel());
            Pages.HomePage.ClickBookRoom();
            Pages.HomePage.IsSuccessMessageDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void WhenCancellingBookingFormShouldNotBeDisplayedTest()
        {
            Pages.HomePage.ClickBookThisRoom();
            Pages.HomePage.CompleteBookingDetails(new UserModel());
            Pages.HomePage.ClickCancelBooking();

        }

        [TestCleanup]
        public override void TestCleanUp()
        {
            base.TestCleanUp();
            _client.CreateRequest($"{ApiResource.Room}/{_roomId}", Method.DELETE);
        }
    }
}
