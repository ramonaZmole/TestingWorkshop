using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingWorkshop.Pages
{
    public class ReportPage
    {
        public bool IsBookingDisplayed(string name, int roomId)
        {
            PageHelpers.ScrollDownToView(1000);
            try
            {
                Browser.WebDriver.FindElement(By.XPath($"//*[contains(text(), '{name} - Room: {roomId}')]"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
