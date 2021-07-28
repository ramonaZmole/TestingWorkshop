using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;

namespace TestingWorkshop.Tests.Admin
{
    [TestClass]
    public class CreateRoomTests : BaseTest
    {

        [TestMethod]
        public void WhenCreatingARoomThenItShouldBeCreatedTest()
        {
            Browser.GoTo(Constants.AdminUrl);

            Pages.LoginPage.Login();
            Pages.RoomPage.CreateRoom(new CreateRoomModel());
        }
    }

}
