using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models.Enum;
using Room = TestingWorkshop.Helpers.Models.Room;

namespace TestingWorkshop.Tests.Admin;

[TestClass]
public class CreateRoomTests : BaseTest
{
    private Room _roomModel = new();

    [DataRow(RoomType.Double)]
    [DataRow(RoomType.Family)]
    [DataRow(RoomType.Single)]
    [DataRow(RoomType.Suite)]
    [DataRow(RoomType.Twin)]
    [TestMethod]
    public void WhenCreatingARoom_ThenItShouldBeCreatedTest(RoomType roomType)
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login();

        Pages.RoomPage.CreateRoom();
        Pages.RoomPage.IsErrorMessageDisplayed().Should().BeTrue();
        var errorMessages = Pages.RoomPage.GetErrorMessages();
        errorMessages.Should().Contain("must be greater than or equal to 1");
        errorMessages.Should().Contain("Room name must be set");

        _roomModel = new Room
        {
            Type = roomType.ToString()
        };
        Pages.RoomPage.InsertRoomDetails(_roomModel);
        Pages.RoomPage.CreateRoom();
        Pages.RoomPage.GetLastRoomDetails().Should().BeEquivalentTo(_roomModel);
    }

    [TestMethod]
    public void WhenCreatingRoomWithNoRoomDetails_NoFeaturesShouldBeDisplayedTest()
    {
        _roomModel.RoomDetails = string.Empty;

        Browser.GoTo(Constants.AdminUrl);
        Pages.LoginPage.Login();

        Pages.RoomPage.InsertRoomDetails(_roomModel);
        Pages.RoomPage.CreateRoom();
        Pages.RoomPage.GetLastRoomDetails().RoomDetails.Should().Be("No features added to the room");
    }


    [TestCleanup]
    public override void After()
    {
        base.After();

        Client.DeleteRoom(_roomModel.RoomName);
    }
}