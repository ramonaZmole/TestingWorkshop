using System.Linq;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using TestingWorkshop.Helpers.Models;

namespace TestingWorkshop.Pages;

public class Homepage : CalendarPage
{
    #region Selectors

    private readonly By _descriptions = By.CssSelector(".row.hotel-room-info p");

    private readonly By _firstNameInput = By.CssSelector(".room-firstname");
    private readonly By _lastNameInput = By.CssSelector(".room-lastname");
    private readonly By _emailInput = By.CssSelector(".room-email");
    private readonly By _phoneInput = By.CssSelector(".room-phone");

    private readonly By _bookRoomButton = By.CssSelector(".btn-outline-primary.book-room");
    private readonly By _cancelBookingButton = By.CssSelector(".btn-outline-danger");
    private readonly By _calendar = By.CssSelector(".rbc-calendar");

    private readonly By _successMessage = By.CssSelector(".col-sm-6.text-center > h3");
    private readonly By _bookRoomButtons = By.CssSelector(".openBooking");

    private readonly By _nameInput = By.CssSelector("#name");
    private readonly By _contactEmailInput = By.CssSelector("#email");
    private readonly By _contactPhoneInput = By.CssSelector("#phone");
    private readonly By _subjectInput = By.CssSelector("#subject");
    private readonly By _messageInput = By.CssSelector("#description");
    private readonly By _submitContactButton = By.CssSelector("#submitContact");

    #endregion

    public void BookRoom() => _bookRoomButton.ActionClick();

    public void CancelBooking() => _cancelBookingButton.ActionClick();

    internal void InsertBookingDetails(User user)
    {
        _firstNameInput.ActionSendKeys(user.FirstName);
        _lastNameInput.ActionSendKeys(user.LastName);
        _emailInput.ActionSendKeys(user.Email);
        _phoneInput.ActionSendKeys(user.ContactPhone);

        SelectDates();
    }

    public void BookThisRoom(string roomDescription)
    {
        var descriptions = _descriptions.GetElements();
        var index = descriptions.IndexOf(descriptions.First(x => x.Text == roomDescription));
        _bookRoomButtons.GetElements()[index].Click();
    }

    public bool IsSuccessMessageDisplayed()
    {
        _successMessage.WaitForElement();
        return _successMessage.GetText().Equals("Booking Successful!");
    }

    public bool IsBookingFormDisplayed()
    {
        return _firstNameInput.IsElementPresent()
               && _lastNameInput.IsElementPresent()
               && _emailInput.IsElementPresent()
               && _phoneInput.IsElementPresent()
               && _bookRoomButton.IsElementPresent()
               && _cancelBookingButton.IsElementPresent();
    }

    public bool IsCalendarDisplayed() => _calendar.IsElementPresent();

    public void SendMessage(ContactForm formData)
    {
        _nameInput.ActionSendKeys(formData.Name);
        _contactEmailInput.ActionSendKeys(formData.Email);
        _contactPhoneInput.ActionSendKeys(formData.Phone);
        _subjectInput.ActionSendKeys(formData.Subject);
        _messageInput.ActionSendKeys(formData.Message);

        _submitContactButton.ActionClick();
    }

}