using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingWorkshop.Helpers
{
    public class CreateRoomInput
    {
        public string roomNumber { get; set; } = Faker.RandomNumber.Next(1,200).ToString();
        public string type { get; set; } = "Twin";
        public string accessible { get; set; } = Faker.Boolean.Random().ToString();
        public string description { get; set; } = Faker.Lorem.Sentence();
        public string image { get; set; } = "https://www.mwtestconsultancy.co.uk/img/room1.jpg";
        public string roomPrice { get; set; } = Faker.RandomNumber.Next(1, 200).ToString();
        public List<string> features { get; set; } = new List<string>();

    }
}
