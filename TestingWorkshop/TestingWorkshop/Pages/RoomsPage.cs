using System.Linq;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using TestingWorkshop.Helpers.Models;

namespace TestingWorkshop.Pages;

public class RoomsPage : BasePage
{
    #region Selectors

    private readonly By _createButton = By.CssSelector("#createRoom");
    private readonly By _roomNumberInput = By.CssSelector("#roomName");
    private readonly By _typeDropDown = By.CssSelector("#type");
    private readonly By _accessibleDropDown = By.CssSelector("#accessible");
    private readonly By _roomPriceInput = By.CssSelector("#roomPrice");
    private readonly By _roomDetailsLabels = By.CssSelector(".form-check-label");

    private readonly By _lastRoomDetails = By.CssSelector("#root > div:nth-child(2) div:nth-last-child(2) .row.detail div");

    #endregion

    public void CreateRoom()
    {
        _createButton.ActionClick();
        WaitHelpers.ExplicitWait();
    }

    public void InsertRoomDetails(Room room)
    {
        _roomNumberInput.ActionSendKeys(room.RoomName);
        _typeDropDown.SelectFromDropdownByText(room.Type);
        _accessibleDropDown.SelectFromDropdownByText(room.Accessible);
        _roomPriceInput.ActionSendKeys(room.Price);
        if (string.IsNullOrEmpty(room.RoomDetails)) return;
        _roomDetailsLabels.GetElements().First(x => x.Text == room.RoomDetails).Click();
    }

    public Room GetLastRoomDetails()
    {
        var roomDetails = _lastRoomDetails.GetElements();

        return new Room
        {
            RoomName = roomDetails[0].Text,
            Type = roomDetails[1].Text,
            Accessible = roomDetails[2].Text,
            Price = roomDetails[3].Text,
            RoomDetails = roomDetails[4].Text
        };
    }
}