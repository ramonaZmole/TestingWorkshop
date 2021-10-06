using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private CreateRoomOutput _createRoomOutput;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            _createRoomOutput = Client.CreateRoom();

            var bookingInput = new CreateBookingInput
            {
                roomid = _createRoomOutput.roomId
            };
            Client.CreateBooking(bookingInput);
        }

        [TestMethod]
        public void WhenBookingRoomErrorMessageShouldBeDisplayedTest()
        {
            Browser.GoTo(Constants.Url);

            Pages.HomePage.ClickBookThisRoom(_createRoomOutput.description);
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
            Client.CreateRequest($"{ApiResource.Room}/{_createRoomOutput.roomId}", Method.DELETE);
        }
    }
}
