using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using TestingWorkshop.Helpers.Model;

namespace TestingWorkshop.Pages
{
    public class RoomPage
    {
        #region Selectors
        private readonly By _createButton = By.CssSelector("#createRoom");
        private readonly By _roomIdInput = By.CssSelector("#roomNumber");
        private readonly By _typeDropDown = By.CssSelector("#type");
        private readonly By _accessibleDropDown = By.CssSelector("#accessible");
        private readonly By _roomPriceInput = By.CssSelector("#roomPrice");
        private readonly By _roomDetailsCheckBoxes = By.CssSelector(".form-check-input");
        private readonly By _roomDetailsLabels = By.CssSelector(".form-check-label");
        #endregion


        private void CreateRoom(CreateRoomModel createRoomModel)
        {
            _roomIdInput.ActionSendKeys(createRoomModel.RoomId);
            _typeDropDown.SelectFromDropdownByText(createRoomModel.Type[Faker.RandomNumber.Next(0,4)]);
            _accessibleDropDown.SelectFromDropdownByText(createRoomModel.Accessible);
            _roomPriceInput.ActionSendKeys(createRoomModel.Price);
            _roomDetailsLabels.GetElements().First(x => x.Text == createRoomModel.RoomDetails).Click();
            _createButton.ActionClick();
        }
    }
}
