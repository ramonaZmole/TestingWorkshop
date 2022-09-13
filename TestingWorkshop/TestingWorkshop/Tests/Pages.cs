using NsTestFrameworkUI.Pages;
using TestingWorkshop.Pages;

namespace TestingWorkshop.Tests;

public static class Pages
{
    public static Homepage HomePage = PageHelpers.InitPage(new Homepage());
    public static LoginPage LoginPage = PageHelpers.InitPage(new LoginPage());
    public static RoomPage RoomPage = PageHelpers.InitPage(new RoomPage());
    public static ReportPage ReportPage = PageHelpers.InitPage(new ReportPage());
    public static AdminHeaderPage AdminHeaderPage = PageHelpers.InitPage(new AdminHeaderPage());
}