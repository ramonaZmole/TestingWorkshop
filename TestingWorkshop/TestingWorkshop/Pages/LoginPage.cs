using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model;

namespace TestingWorkshop.Pages
{
    public class LoginPage
    {
        #region Selectors
        private readonly By _usernameInput = By.CssSelector("#username");
        private readonly By _passwordInput = By.CssSelector("#password");
        private readonly By _loginButton = By.CssSelector("#doLogin");

        #endregion

        public void Login()
        {
            _usernameInput.ActionSendKeys(Constants.Username);
            _passwordInput.ActionSendKeys(Constants.Password);
            _loginButton.ActionClick();
        }

    }
}
