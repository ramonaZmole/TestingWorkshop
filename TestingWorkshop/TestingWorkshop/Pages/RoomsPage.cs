using System.Linq;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using TestingWorkshop.Helpers.Model;

namespace TestingWorkshop.Pages;

public class RoomsPage
{
    #region Selectors

    private readonly By _createButton = By.CssSelector("#createRoom");
    private readonly By _roomNumberInput = By.CssSelector("#roomName");
    private readonly By _typeDropDown = By.CssSelector("#type");
    private readonly By _accessibleDropDown = By.CssSelector("#accessible");
    private readonly By _roomPriceInput = By.CssSelector("#roomPrice");
    private readonly By _roomDetailsLabels = By.CssSelector(".form-check-label");
    private readonly By _errorMessage = By.CssSelector(".alert ");

    private readonly By _lastRoomDetails =
        By.CssSelector("#root > div:nth-child(2) div:nth-last-child(2) .row.detail div");

    #endregion

    public void CreateRoom()
    {
        _createButton.ActionClick();
        WaitHelpers.ExplicitWait();
    }

    public void FillForm(CreateRoomModel createRoomModel)
    {
        _roomNumberInput.ActionSendKeys(createRoomModel.RoomName);
        _typeDropDown.SelectFromDropdownByText(createRoomModel.Type);
        _accessibleDropDown.SelectFromDropdownByText(createRoomModel.Accessible);
        _roomPriceInput.ActionSendKeys(createRoomModel.Price);
        if (string.IsNullOrEmpty(createRoomModel.RoomDetails)) return;
        _roomDetailsLabels.GetElements().First(x => x.Text == createRoomModel.RoomDetails).Click();
    }

    public CreateRoomModel GetLastCreatedRoomDetails()
    {
        var roomDetails = _lastRoomDetails.GetElements();

        return new CreateRoomModel
        {
            RoomName = roomDetails[0].Text,
            Type = roomDetails[1].Text,
            Accessible = roomDetails[2].Text,
            Price = roomDetails[3].Text,
            RoomDetails = roomDetails[4].Text
        };
    }

    public bool IsErrorMessageDisplayed()
    {
        var errorMessage = _errorMessage.GetText();
        return _errorMessage.IsElementPresent()
               && errorMessage.Contains("must be greater than or equal to 1")
               && errorMessage.Contains("Room name must be set");
    }
}