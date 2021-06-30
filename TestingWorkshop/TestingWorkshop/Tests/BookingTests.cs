using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
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
        private readonly CreateRoomInput _createRoomInput = new CreateRoomInput();

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var roomResponse = Client.CreateRequest(ApiResource.Room, _createRoomInput, Method.POST);
            _roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(roomResponse.Content).roomId;
        }

        [TestMethod]
        public void WhenBookingRoomSuccessMessageShouldBeDisplayedTest()
        {
            Browser.GoTo(Constants.Url);

            Pages.HomePage.ClickBookThisRoom(_createRoomInput.description);
            Pages.HomePage.CompleteBookingDetails(new UserModel());
            Pages.HomePage.ClickBookRoom();
            Pages.HomePage.IsSuccessMessageDisplayed().Should().BeTrue();
        }

        [TestMethod]
        public void WhenCancellingBookingFormShouldNotBeDisplayedTest()
        {
            Browser.GoTo(Constants.Url);

            Pages.HomePage.ClickBookThisRoom(_createRoomInput.description);
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
