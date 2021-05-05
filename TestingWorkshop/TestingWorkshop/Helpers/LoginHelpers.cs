using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using RestSharp;
using TestingWorkshop.Helpers.Model.ApiModels;

namespace TestingWorkshop.Helpers
{
    public static class LoginHelpers
    {
        public static string GetLoginToken(this RestClient client)
        {

            var output = client.CreateRequest(ApiResource.Login, new LoginModelInput(), Method.POST).Content;
            return JsonConvert.DeserializeObject<LoginModelOutput>(output).token;
        }
    }
}
