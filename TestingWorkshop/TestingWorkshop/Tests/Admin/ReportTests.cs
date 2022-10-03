using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkApi.RestSharp;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;
using TestingWorkshop.Helpers.Models.ApiModels;

namespace TestingWorkshop.Tests.Admin;

[TestClass]
public class ReportTests : BaseTest
{
    private CreateRoomOutput _createRoomOutput;
    private CreateBookingInput _bookingInput;

    [TestInitialize]
    public override void Before()
    {
        base.Before();
        _createRoomOutput = Client.CreateRoom();

        _bookingInput = new CreateBookingInput
        {
            roomid = _createRoomOutput.roomid
        };
        Client.CreateBooking(_bookingInput);
    }

    [TestMethod]
    public void WhenBookingARoom_DatePeriodShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login();
        Pages.AdminHeaderPage.GoToMenu(Menu.Report);

        var bookingName = $"{_bookingInput.firstname} {_bookingInput.lastname}";
        Pages.ReportPage.IsBookingDisplayed(bookingName, _createRoomOutput.roomName).Should().BeTrue();
    }


    [TestCleanup]
    public override void After()
    {
        base.After();
        var t = Client.CreateRequest($"{ApiResource.Room}{_createRoomOutput.roomid}", Method.DELETE);
    }
}