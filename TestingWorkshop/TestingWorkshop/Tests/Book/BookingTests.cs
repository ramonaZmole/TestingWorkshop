using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;
using TestingWorkshop.Helpers.Models.ApiModels;

namespace TestingWorkshop.Tests.Book;

[TestClass]
public class BookingTests : BaseTest
{
    private CreateRoomOutput _createRoomOutput;

    [TestInitialize]
    public override void Before()
    {
        base.Before();

        _createRoomOutput = Client.CreateRoom();
    }

    [TestMethod]
    public void WhenBookingRoom_SuccessMessageShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.BookThisRoom(_createRoomOutput.description);
        Pages.Homepage.InsertBookingDetails(new User());
        Pages.Homepage.BookRoom();
        Pages.Homepage.IsSuccessMessageDisplayed().Should().BeTrue();
    }

    [TestMethod]
    public void WhenCancellingBooking_FormShouldNotBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.BookThisRoom(_createRoomOutput.description);
        Pages.Homepage.InsertBookingDetails(new User());
        Pages.Homepage.CancelBooking();
        Pages.Homepage.IsBookingFormDisplayed().Should().BeFalse();
        Pages.Homepage.IsCalendarDisplayed().Should().BeFalse();
    }

    [TestCleanup]
    public override void After()
    {
        base.After();

        Client.DeleteRoom(_createRoomOutput.roomid);
    }
}