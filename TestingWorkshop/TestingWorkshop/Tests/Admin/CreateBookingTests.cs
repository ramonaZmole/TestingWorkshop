using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;
using TestingWorkshop.Helpers.Models.ApiModels;
using Room = TestingWorkshop.Helpers.Models.Room;

namespace TestingWorkshop.Tests.Admin
{
    [TestClass]
    public class CreateBookingTests : BaseTest
    {
        private CreateRoomOutput _createRoomOutput;
        private User user = new();
        private Room room;

        [TestInitialize]
        public override void Before()
        {
            base.Before();
            _createRoomOutput = Client.CreateRoom();
            room = new Room
            {
                RoomName = _createRoomOutput.roomName.ToString()
            };
        }

        [TestMethod]
        public void WhenBookingARoom_BookingShouldBeDisplayedTest()
        {
            Browser.GoTo(Constants.AdminUrl);

            Pages.LoginPage.Login();
            Pages.AdminHeaderPage.GoToMenu(Menu.Report);

            Pages.ReportPage.SelectDates();
            Pages.ReportPage.Book();
            Pages.ReportPage.IsErrorMessageDisplayed().Should().BeTrue();

            Pages.ReportPage.InsertBookingDetails(user, room);
            Pages.ReportPage.Book();

            var bookingName = $"{user.FirstName} {user.LastName}";
            Pages.ReportPage.IsBookingDisplayed(bookingName, _createRoomOutput.roomName).Should().BeTrue();
        }


        [TestCleanup]
        public override void After()
        {
            base.After();
            var t = Client.CreateRequest($"{ApiResource.Room}{_createRoomOutput.roomid}", Method.DELETE);
        }
    }
}
