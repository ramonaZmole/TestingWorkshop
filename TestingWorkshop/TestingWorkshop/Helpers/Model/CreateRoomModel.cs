using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWorkshop.Helpers.Model
{
    public class CreateRoomModel
    {
        public string RoomId { get; set; } = Faker.RandomNumber.Next().ToString();
        public List<string> Type { get; set; } = new() { "Single", "Twin", "Double", "Family", "Suite" };
        public string Accessible { get; set; } = Faker.Boolean.Random().ToString();
        public string Price { get; set; } = Faker.RandomNumber.Next().ToString();
        public string RoomDetails { get; set; } = GetRoomDetails();



        public static string GetRoomDetails()
        {
            var RoomDetails = new List<string>{ "WiFi", "TV", "Radio", "Refreshments", "Safe", "Views" };

            return RoomDetails[Faker.RandomNumber.Next(5)];
        }
    }
}
