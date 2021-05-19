using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using NsTestFrameworkApi.RestSharp;
using RestSharp;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Model.ApiModels;

namespace TestingWorkshop.Tests
{
    [TestClass]
    public class BookingFormTests : BaseTest
    {
        private readonly RestClient _client = RequestHelper.GetRestClient(Constants.Url);
        private int _roomId;

        [TestInitialize]
        public override void TestInitialize()
        {
            var token = _client.GetLoginToken();
            _client.AddDefaultHeader("cookie", $"token={token}");
            var response = _client.CreateRequest(ApiResource.Room, new CreateRoomInput(), Method.POST);
            _roomId = JsonConvert.DeserializeObject<CreateRoomOutput>(response.Content).roomId;
            base.TestInitialize();
            var booking = new CreateBookingInput()
            {
                roomid = _roomId
            };
            var bookingResponse = _client.CreateRequest(ApiResource.Booking, booking, Method.POST);

        }

        [TestMethod]
        public void Test()
        {

        }
    }
}
