using System.Collections.Generic;

namespace TestingWorkshop.Helpers.Models.ApiModels;

public class CreateRoomInput
{
    public string roomName { get; set; } = RandomNumber.Next(1, 200).ToString();
    public string type { get; set; } = "Twin";
    public string accessible { get; set; } = Boolean.Random().ToString();
    public string description { get; set; } = Lorem.Sentence();
    public string image { get; set; } = "https://www.mwtestconsultancy.co.uk/img/room1.jpg";
    public string roomPrice { get; set; } = RandomNumber.Next(1, 200).ToString();
    public List<string> features { get; set; } = new() { "WiFi", "Radio", "Safe" };

}