using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWorkshop.Helpers
{
    public class CreateRoomInput
    {
        public string RoomNumber { get; set; } = Faker.RandomNumber.Next(1,200).ToString();
        public string Type { get; set; } = "Twin";
        public string Accessible { get; set; } = Faker.Boolean.Random().ToString();
        public string Description { get; set; } = Faker.Lorem.Sentence();
        public string Image { get; set; } = "https://www.mwtestconsultancy.co.uk/img/room1.jpg";
        public string RoomPrice { get; set; } = Faker.RandomNumber.Next(1, 200).ToString();
        public List<string> Features { get; set; }

    }
}
