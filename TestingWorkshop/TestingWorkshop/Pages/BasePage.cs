using System.Collections.Generic;
using System.Linq;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace TestingWorkshop.Pages
{
    public class BasePage
    {
        private readonly By _errorMessages = By.CssSelector(".alert.alert-danger p");



        public List<string> GetErrorMessages()
        {
            WaitHelpers.ExplicitWait();
            return _errorMessages.GetElements().Select(x => x.Text).ToList();
        }

        public bool IsErrorMessageDisplayed() => _errorMessages.AreElementsPresent();

    }
}
