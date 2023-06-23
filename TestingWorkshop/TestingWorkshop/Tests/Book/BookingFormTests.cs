using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;
using TestingWorkshop.Helpers.Models.ApiModels;

namespace TestingWorkshop.Tests.Book;

[TestClass]
public class BookingFormTests : BaseTest
{
    private CreateRoomOutput _createRoomOutput;

    [TestInitialize]
    public override void Before()
    {
        base.Before();

        _createRoomOutput = Client.CreateRoom();

        var bookingInput = new CreateBookingInput
        {
            roomid = _createRoomOutput.roomid
        };
        Client.CreateBooking(bookingInput);
    }

    [TestMethod]
    public void WhenBookingRoom_ErrorMessageShouldBeDisplayedTest()
    {
        Browser.GoTo(Constants.Url);

        Pages.HomePage.BookThisRoom(_createRoomOutput.description);
        Pages.HomePage.BookRoom();
        Pages.HomePage.GetErrorMessages().Should().BeEquivalentTo(Constants.FormErrorMessages);

        Pages.HomePage.InsertBookingDetails(new User());
        Pages.HomePage.BookRoom();
        Pages.HomePage.GetErrorMessages()[0].Should().Be(Constants.AlreadyBookedErrorMessage);
    }

    [TestCleanup]
    public override void After()
    {
        base.After();
        Client.CreateRequest($"{ApiResource.Room}{_createRoomOutput.roomid}", Method.DELETE);
    }
}