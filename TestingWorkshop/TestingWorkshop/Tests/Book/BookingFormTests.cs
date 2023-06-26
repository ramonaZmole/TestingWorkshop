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

        Pages.Homepage.BookThisRoom(_createRoomOutput.description);
        Pages.Homepage.BookRoom();
        Pages.Homepage.GetErrorMessages().Should().BeEquivalentTo(Messages.FormErrorMessages);

        Pages.Homepage.InsertBookingDetails(new User());
        Pages.Homepage.BookRoom();
        Pages.Homepage.GetErrorMessages()[0].Should().Be(Messages.AlreadyBookedErrorMessage);
    }

    [TestCleanup]
    public override void After()
    {
        base.After();

        Client.DeleteRoom(_createRoomOutput.roomid);
    }
}