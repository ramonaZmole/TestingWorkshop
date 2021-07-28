using NsTestFrameworkUI.Pages;
using TestingWorkshop.Pages;

namespace TestingWorkshop.Tests
{
    public static class Pages
    {
        public static Homepage HomePage = PageHelpers.InitPage(new Homepage());
        public static LoginPage LoginPage = PageHelpers.InitPage(new LoginPage());
        public static RoomPage RoomPage = PageHelpers.InitPage(new RoomPage());
    }
}
