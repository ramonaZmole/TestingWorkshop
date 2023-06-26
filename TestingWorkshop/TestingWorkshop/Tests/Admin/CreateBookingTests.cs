using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;
using TestingWorkshop.Helpers.Models.ApiModels;
using TestingWorkshop.Helpers.Models.Enum;
using Room = TestingWorkshop.Helpers.Models.Room;

namespace TestingWorkshop.Tests.Admin;

[TestClass]
public class CreateBookingTests : BaseTest
{
    private CreateRoomOutput _createRoomOutput;
    private readonly User _user = new();
    private Room _room = new();

    [TestInitialize]
    public override void Before()
    {
        base.Before();

        _createRoomOutput = Client.CreateRoom();

        _room = new Room
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

        Pages.ReportPage.InsertBookingDetails(_user, _room);
        Pages.ReportPage.Book();

        var bookingName = $"{_user.FirstName} {_user.LastName}";
        Pages.ReportPage.IsBookingDisplayed(bookingName, _createRoomOutput.roomName).Should().BeTrue();
    }


    [TestCleanup]
    public override void After()
    {
        base.After();

        Client.DeleteRoom(_createRoomOutput.roomid);
    }
}