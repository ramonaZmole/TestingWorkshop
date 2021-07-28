using System.Linq;
using NsTestFrameworkUI.Helpers;
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
        private readonly By _roomDetailsLabels = By.CssSelector(".form-check-label");

        private readonly By _lastRoomDetails =
            By.CssSelector("#root > div:nth-child(2) div:nth-last-child(2) .row.detail div");

        #endregion


        public void CreateRoom(CreateRoomModel createRoomModel)
        {
            _roomIdInput.ActionSendKeys(createRoomModel.RoomId);
            _typeDropDown.SelectFromDropdownByText(createRoomModel.Type);
            _accessibleDropDown.SelectFromDropdownByText(createRoomModel.Accessible);
            _roomPriceInput.ActionSendKeys(createRoomModel.Price);
            _roomDetailsLabels.GetElements().First(x => x.Text == createRoomModel.RoomDetails).Click();
            _createButton.ActionClick();
            WaitHelpers.ExplicitWait();
        }

        public CreateRoomModel GetLastCreatedRoomDetails()
        {
            var roomDetails = _lastRoomDetails.GetElements();

            return new CreateRoomModel
            {
                RoomId = roomDetails[0].Text,
                Type = roomDetails[1].Text,
                Accessible = roomDetails[2].Text,
                Price = roomDetails[3].Text,
                RoomDetails = roomDetails[4].Text
            };
        }
    }
}
