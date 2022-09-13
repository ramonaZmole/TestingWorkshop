using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System.Linq;
using TestingWorkshop.Helpers.Model;

namespace TestingWorkshop.Pages;

public class AdminHeaderPage
{
    private readonly By _menuItems = By.CssSelector(".mr-auto li a"); 


    public void GoToMenu(MenuItems menuItem)
    {
        _menuItems.GetElements().First(x => x.Text.Equals(menuItem.ToString())).Click();
    }
}