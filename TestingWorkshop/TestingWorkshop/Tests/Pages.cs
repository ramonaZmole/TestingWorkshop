using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Pages;
using TestingWorkshop.Pages;

namespace TestingWorkshop.Tests
{
    public static class Pages
    {
        public static Homepage HomePage = PageHelpers.InitPage(new Homepage());
    }
}
