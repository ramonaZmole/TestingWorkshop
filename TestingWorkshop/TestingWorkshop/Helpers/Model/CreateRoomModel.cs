using System.Collections.Generic;

namespace TestingWorkshop.Helpers.Model
{
    public class CreateRoomModel
    {
        public string RoomId { get; set; } = Faker.RandomNumber.Next(0, 1000).ToString();
        public List<string> Type { get; set; } = new() { "Single", "Twin", "Double", "Family", "Suite" };
        public string Accessible { get; set; } = Faker.Boolean.Random().ToString().ToLower();
        public string Price { get; set; } = Faker.RandomNumber.Next(0,999).ToString();
        public string RoomDetails { get; set; } = GetRoomDetails();



        public static string GetRoomDetails()
        {
            var roomDetails = new List<string>{ "WiFi", "TV", "Radio", "Refreshments", "Safe", "Views" };

            return roomDetails[Faker.RandomNumber.Next(roomDetails.Count - 1)];
        }
    }
}
