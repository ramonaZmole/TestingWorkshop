﻿using System.IO;
using System.Reflection;
using RestSharp;

[assembly: Parallelize(Workers = 4, Scope = ExecutionScope.MethodLevel)]
namespace TestingWorkshop.Helpers;

public class BaseTest
{
    public TestContext TestContext { get; set; }
    public readonly RestClient Client = RequestHelper.GetRestClient(Constants.Url);

    [TestInitialize]
    public virtual void Before()
    {
        SetClientToken();
        Browser.InitializeDriver(new DriverOptions
        {
            IsHeadless = true,
            ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
        });
        Browser.WebDriver.Manage().Window.Maximize();
    }

    [TestCleanup]
    public virtual void After()
    {
        if (TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
        {
            var path = ScreenShot.GetScreenShotPath(TestContext.TestName);
            TestContext.AddResultFile(path);
        }
        Browser.Cleanup();
    }

    private void SetClientToken()
    {
        var token = Client.GetLoginToken();
        Client.AddDefaultHeader("cookie", $"token={token}");
    }
}