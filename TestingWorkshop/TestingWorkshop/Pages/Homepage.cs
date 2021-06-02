using System;
using System.Collections.Generic;
using System.Linq;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestingWorkshop.Helpers.Model;

namespace TestingWorkshop.Pages
{
    public class Homepage
    {
        #region Selectors

        private readonly By _firstNameInput = By.CssSelector(".room-firstname");
        private readonly By _lastNameInput = By.CssSelector(".room-lastname");
        private readonly By _emailInput = By.CssSelector(".room-email");
        private readonly By _phoneInput = By.CssSelector(".room-phone");

        private readonly By _bookRoomButton = By.CssSelector(".btn-outline-primary.book-room");
        private readonly By _cancelBookingButton = By.CssSelector(".btn-outline-danger");
        private readonly By _calendar = By.CssSelector(".rbc-calendar");

        private readonly By _successMessage = By.CssSelector(".col-sm-6.text-center > h3");
        private readonly By _bookRoomButtons = By.CssSelector(".openBooking");

        private readonly By _errorMessages = By.CssSelector(".alert.alert-danger p");
        #endregion

        public void ClickBookRoom()
        {
            _bookRoomButton.ActionClick();
        }

        public void CancelBooking() => _cancelBookingButton.ActionClick();

        internal void CompleteBookingDetails(UserModel userModel)
        {
            _firstNameInput.ActionSendKeys(userModel.FirstName);
            _lastNameInput.ActionSendKeys(userModel.LastName);
            _emailInput.ActionSendKeys(userModel.Email);
            _phoneInput.ActionSendKeys(userModel.ContactPhone);

            SelectDates(DateTime.Now.ToString("dd"));
        }

        public void ClickBookThisRoom()
        {
            _bookRoomButtons.GetElements().Last().Click();
        }

        private static void SelectDates(string dayOfMonth)
        {
            var actions = new Actions(Browser.WebDriver);

            actions.ClickAndHold(Browser.WebDriver.FindElement(By.XPath($"//div[not(contains(@class, 'rbc-off-range'))]/a[text()=\"{dayOfMonth}\"] ")))
                  .MoveByOffset(10, 10)
                  .MoveByOffset(100, 0)
                  .Release()
                  .Build()
                  .Perform();
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

        public bool IsCalendarDisplayed()
        {
            return _calendar.IsElementPresent();
        }

        public List<string> GetErrorMessages()
        {
            WaitHelpers.ExplicitWait();
            return _errorMessages.GetElements().Select(x => x.Text).ToList();
        }
    }
}
