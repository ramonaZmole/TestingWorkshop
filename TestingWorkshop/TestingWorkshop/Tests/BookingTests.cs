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
        private int _roomId;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var roomResponse = Client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
            _roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(roomResponse.Content).roomId;
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
            Pages.HomePage.CancelBooking();
            Pages.HomePage.IsBookingFormDisplayed().Should().BeFalse();
            Pages.HomePage.IsCalendarDisplayed().Should().BeFalse();
        }

        [TestCleanup]
        public override void TestCleanUp()
        {
            base.TestCleanUp();
            Client.CreateRequest($"{ApiResource.Room}/{_roomId}", Method.DELETE);
        }
    }
}
