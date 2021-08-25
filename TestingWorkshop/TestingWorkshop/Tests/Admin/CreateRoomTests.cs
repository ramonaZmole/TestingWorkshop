using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;

namespace TestingWorkshop.Tests.Admin
{
    [TestClass]
    public class CreateRoomTests : BaseTest
    {
        private readonly CreateRoomModel _roomModel = new CreateRoomModel();

        [TestMethod]
        public void WhenCreatingARoomThenItShouldBeCreatedTest()
        {
            Browser.GoTo(Constants.AdminUrl);

            Pages.LoginPage.Login();

            Pages.RoomPage.CreateRoom();
            Pages.RoomPage.IsErrorMessageDisplayed().Should().BeTrue();

            Pages.RoomPage.FillForm(_roomModel);
            Pages.RoomPage.CreateRoom();
            Pages.RoomPage.GetLastCreatedRoomDetails().Should().BeEquivalentTo(_roomModel);
        }

        [TestMethod]
        public void WhenCreatingRoomWithNoRoomDetailsNoFeaturesShouldBeDisplayedTest()
        {
            _roomModel.RoomDetails = string.Empty;

            Browser.GoTo(Constants.AdminUrl);
            Pages.LoginPage.Login();

            Pages.RoomPage.FillForm(_roomModel);
            Pages.RoomPage.CreateRoom();
            Pages.RoomPage.GetLastCreatedRoomDetails().RoomDetails.Should().Be("No features added to the room");
        }
    }

}
