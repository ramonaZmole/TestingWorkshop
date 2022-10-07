using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using TestingWorkshop.Helpers;

namespace TestingWorkshop.Pages
{
    public class CalendarPage : BasePage
    {
        public void SelectDates()
        {
            var actions = new Actions(Browser.WebDriver);

            actions.ClickAndHold(Browser.WebDriver.FindElement(By.XPath($"//*[text()={Constants.BookingStartDay}] ")))
                .MoveByOffset(10, 10)
                .Release(Browser.WebDriver.FindElement(By.XPath($"//*[text()={Constants.BookingEndDay}] ")))
                .Build()
                .Perform();
        }
    }
}
