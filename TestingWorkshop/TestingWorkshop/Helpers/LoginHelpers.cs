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
            var output = client.CreateRequest(ApiResource.Login, new LoginInput(), Method.POST).Content;
            return JsonConvert.DeserializeObject<LoginOutput>(output).token;
        }
    }
}
