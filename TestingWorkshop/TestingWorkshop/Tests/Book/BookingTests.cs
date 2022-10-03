using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NsTestFrameworkApi.RestSharp;
using NsTestFrameworkUI.Helpers;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;
using TestingWorkshop.Helpers.Models.ApiModels;

namespace TestingWorkshop.Tests.Book;

[TestClass]
public class BookingTests : BaseTest
{
    private CreateRoomOutput _createRoomResponse;

    [TestInitialize]
    public override void Before()
    {
        base.Before();

        _createRoomResponse = Client.CreateRoom();
    }

    [TestMethod]
    public void WhenBookingRoom_SuccessMessageShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.HomePage.BookThisRoom(_createRoomResponse.description);
        Pages.HomePage.InsertBookingDetails(new User());
        Pages.HomePage.BookRoom();
        Pages.HomePage.IsSuccessMessageDisplayed().Should().BeTrue();
    }

    [TestMethod]
    public void WhenCancellingBooking_FormShouldNotBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.HomePage.BookThisRoom(_createRoomResponse.description);
        Pages.HomePage.InsertBookingDetails(new User());
        Pages.HomePage.CancelBooking();
        Pages.HomePage.IsBookingFormDisplayed().Should().BeFalse();
        Pages.HomePage.IsCalendarDisplayed().Should().BeFalse();
    }

    [TestCleanup]
    public override void After()
    {
        base.After();
        Client.CreateRequest($"{ApiResource.Room}{_createRoomResponse.roomid}", Method.DELETE);
    }
}