using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestingWorkshop.Pages
{
    internal class Homapage
    {
        private readonly By _bookThisRoomButton = By.CssSelector(".openBooking");
        private readonly By _firstNameInput = By.CssSelector(".room-firstname");
        private readonly By _lastNameInput = By.CssSelector(".room-lastname");
        private readonly By _emailInput = By.CssSelector(".room-email");
        private readonly By _phoneInput = By.CssSelector(".room-phone");
        private readonly By _bookRoomButton = By.CssSelector(".btn-outline-primary.book-room");
    }
}
