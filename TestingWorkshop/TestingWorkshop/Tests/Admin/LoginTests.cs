using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper.Configuration;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;
using System.Reflection;

namespace TestingWorkshop.Tests.Admin;

[TestClass]
public class LoginTests : BaseTest
{
    [DataRow("admin", "password", true)]
    [DataRow("invalidUser", "invalidPassword", false)]
    [TestMethod]
    public void LoginAsAdmin(string username, string password, bool isLoggedIn)
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login(username, password);

        Pages.AdminHeaderPage.IsLogoutButtonDisplayed().Should().Be(isLoggedIn);
    }

    [DynamicData(nameof(GetLoginScenarios), DynamicDataSourceType.Method)]
    [TestMethod]
    public void LoginAsAdmin(LoginData loginData)
    {
        Browser.GoTo(Constants.AdminUrl);

        Pages.LoginPage.Login(loginData.Username, loginData.Password);

        Pages.AdminHeaderPage.IsLogoutButtonDisplayed().Should().Be(loginData.IsLoggedIn);
    }

    private static IEnumerable<object[]> GetLoginScenarios()
    {
        var dataFilePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\Helpers\Data\LoginData.csv";

        using var stream = new StreamReader(dataFilePath);
        using var reader = new CsvReader(stream, new CsvConfiguration(CultureInfo.CurrentCulture));
        var rows = reader.GetRecords<LoginData>();

        foreach (var row in rows)
        {
            yield return new object[] { row };
        }
    }
}