using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;
using TestingWorkshop.Helpers.Model.ApiModels;

namespace TestingWorkshop.Tests.Book;

[TestClass]
public class BookingTests : BaseTest
{
    private CreateRoomOutput _createRoomResponse;

    [TestInitialize]
    public override void TestInitialize()
    {
        base.TestInitialize();

        _createRoomResponse = Client.CreateRoom();
    }

    [TestMethod]
    public void WhenBookingRoomSuccessMessageShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.HomePage.ClickBookThisRoom(_createRoomResponse.description);
        Pages.HomePage.CompleteBookingDetails(new UserModel());
        Pages.HomePage.ClickBookRoom();
        Pages.HomePage.IsSuccessMessageDisplayed().Should().BeTrue();
    }

    [TestMethod]
    public void WhenCancellingBookingFormShouldNotBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.HomePage.ClickBookThisRoom(_createRoomResponse.description);
        Pages.HomePage.CompleteBookingDetails(new UserModel());
        Pages.HomePage.CancelBooking();
        Pages.HomePage.IsBookingFormDisplayed().Should().BeFalse();
        Pages.HomePage.IsCalendarDisplayed().Should().BeFalse();
    }

    [TestCleanup]
    public override void TestCleanUp()
    {
        base.TestCleanUp();
        Client.CreateRequest($"{ApiResource.Room}{_createRoomResponse.roomid}", Method.DELETE);
    }
}