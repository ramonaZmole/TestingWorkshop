using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;
using TestingWorkshop.Helpers.Model.ApiModels;

namespace TestingWorkshop.Tests.Book
{
    [TestClass]
    public class BookingFormTests : BaseTest
    {
        private int _roomId;
        private readonly CreateRoomInput _createRoomInput = new CreateRoomInput();

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            var roomResponse = Client.CreateRequest(ApiResource.Room, _createRoomInput, Method.POST);
            _roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(roomResponse.Content).roomId;

            var bookingInput = new CreateBookingInput
            {
                roomid = _roomId,
            };

            bookingInput.bookingdates.checkin = bookingInput.bookingdates.checkin.Remove(8, 2).Insert(8, Constants.BookingStartDay);
            bookingInput.bookingdates.checkout = bookingInput.bookingdates.checkout.Remove(8, 2).Insert(8, Constants.BookingEndDay);
            Client.CreateRequest(ApiResource.Booking, bookingInput, Method.POST);
        }

        [TestMethod]
        public void WhenBookingRoomErrorMessageShouldBeDisplayedTest()
        {
            Browser.GoTo(Constants.Url);

            Pages.HomePage.ClickBookThisRoom(_createRoomInput.description);
            Pages.HomePage.ClickBookRoom();
            Pages.HomePage.GetErrorMessages().Should().BeEquivalentTo(Constants.FormErrorMessages);

            Pages.HomePage.CompleteBookingDetails(new UserModel());
            Pages.HomePage.ClickBookRoom();
            Pages.HomePage.GetErrorMessages()[2].Should().Be(Constants.AlreadyBookedErrorMessage);
        }

        [TestCleanup]
        public override void TestCleanUp()
        {
            base.TestCleanUp();
            Client.CreateRequest($"{ApiResource.Room}/{_roomId}", Method.DELETE);
        }
    }
}
