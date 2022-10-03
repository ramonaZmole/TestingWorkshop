using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System.Linq;
using TestingWorkshop.Helpers.Models;

namespace TestingWorkshop.Pages;

public class AdminHeaderPage
{
    private readonly By _menuItems = By.CssSelector(".mr-auto li a"); 


    public void GoToMenu(Menu menu)
    {
        _menuItems.GetElements().First(x => x.Text.Equals(menu.ToString())).Click();
    }
}