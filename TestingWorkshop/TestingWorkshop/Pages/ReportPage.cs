using System;
using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;

namespace TestingWorkshop.Pages
{
    public class ReportPage
    {
        public bool IsBookingDisplayed(string name, int roomId)
        {
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
