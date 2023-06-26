namespace TestingWorkshop.Helpers.Models;

public class User
{
    public string FirstName { get; set; } = Name.First();
    public string LastName { get; set; } = Name.Last();
    public string Email { get; set; } = Internet.Email();
    public string ContactPhone { get; set; } = "89123749157";
}