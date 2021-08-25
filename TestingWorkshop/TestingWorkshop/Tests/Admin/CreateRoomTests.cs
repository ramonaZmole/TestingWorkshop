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
            Pages.RoomPage.CreateRoom(_roomModel);
            Pages.RoomPage.GetLastCreatedRoomDetails().Should().BeEquivalentTo(_roomModel);
        }
    }

}
