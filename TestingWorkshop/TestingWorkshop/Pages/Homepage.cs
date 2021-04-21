using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestingWorkshop.Pages
{
    public class Homepage
    {
        #region Selectors

        private readonly By _bookThisRoomButton = By.CssSelector(".openBooking");

        private readonly By _firstNameInput = By.CssSelector(".room-firstname");
        private readonly By _lastNameInput = By.CssSelector(".room-lastname");
        private readonly By _emailInput = By.CssSelector(".room-email");
        private readonly By _phoneInput = By.CssSelector(".room-phone");

        private readonly By _bookRoomButton = By.CssSelector(".btn-outline-primary.book-room");
        private readonly By _startDate = By.CssSelector(".rbc-calendar .rbc-month-row:nth-child(3) .rbc-date-cell:first-child");

        private readonly By _succesMessage = By.CssSelector(".col-sm-6.text-center > h3");
        private readonly By _bookRoomButtons = By.CssSelector(".openBooking");
        #endregion

        
        public void ClickBookRoom()
        {
            _bookRoomButton.ActionClick();
        }

        public void InsertContactData(string firstName, string lastName, string email, string phone)
        {
            _firstNameInput.ActionSendKeys(firstName);
            _lastNameInput.ActionSendKeys(lastName);
            _emailInput.ActionSendKeys(email);
            _phoneInput.ActionSendKeys(phone);
        }

        public void ClickBookThisRoomButton()
        {
            //_bookRoomButton.ActionClick();
            var roomButtons = _bookRoomButtons.GetElements();
            roomButtons.Last().Click();
        }

        public void SelectDates()
        {
            var actions = new Actions(Browser.WebDriver);

            var location = Browser.WebDriver.FindElement(_startDate).Location;

            actions.ClickAndHold(Browser.WebDriver.FindElement(_startDate))
                  .MoveByOffset(20, 10)
                  .MoveByOffset(100, 0)
                  .Release()
                  .Build()
                  .Perform();
        }

        public bool IsSuccesfullBooking()
        {
            WaitHelpers.WaitForElement(_succesMessage);
            return _succesMessage.GetText().Equals("Booking Successful!");
        }








    }


}
