using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using System.Linq;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;
using TestingWorkshop.Helpers.Model.ApiModels;

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

        [TestCleanup]
        public override void TestCleanUp()
        {
            base.TestCleanUp();
            var response = Client.CreateRequest(ApiResource.Room);
            var roomsList = JsonConvert.DeserializeObject<GetRoomsOutput>(response.Content);
            var id = roomsList.rooms.First(x => x.roomNumber == int.Parse(_roomModel.RoomNumber)).roomid;
            Client.CreateRequest($"{ApiResource.Room}/{id}", RestSharp.Method.DELETE);
        }
    }

}
