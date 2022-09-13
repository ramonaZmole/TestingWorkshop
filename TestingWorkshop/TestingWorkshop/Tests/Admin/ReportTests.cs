using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkApi.RestSharp;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model.ApiModels;

namespace TestingWorkshop.Tests.Admin
{
    [TestClass]
    public class ReportTests : BaseTest
    {
        private CreateRoomOutput _createRoomOutput;
        private CreateBookingInput _bookingInput;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _createRoomOutput = Client.CreateRoom();

            _bookingInput = new CreateBookingInput
            {
                roomid = _createRoomOutput.roomId
            };
            Client.CreateBooking(_bookingInput);
        }

        [TestMethod]
        public void WhenBookingARoomDatePeriodShouldBeDisplayedTest()
        {
            Browser.GoTo(Constants.AdminUrl);

            Pages.LoginPage.Login();
            Pages.AdminHeaderPage.GoToMenu(Helpers.Model.MenuItems.Report);

            var bookingName = $"{_bookingInput.firstname} {_bookingInput.lastname}";
            Pages.ReportPage.IsBookingDisplayed(bookingName, _createRoomOutput.roomNumber).Should().BeTrue();
        }


        [TestCleanup]
        public override void TestCleanUp()
        {
            base.TestCleanUp();
            Client.CreateRequest($"{ApiResource.Room}/{_createRoomOutput.roomId}", Method.DELETE);
        }
    }
}
