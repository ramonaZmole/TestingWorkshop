namespace TestingWorkshop.Helpers.Models;

public class ContactForm
{
    public string Name { get; set; } = Faker.Name.FullName();
    public string Email { get; set; } = Internet.Email();
    public string Phone { get; set; } = "89123749157";
    public string Subject { get; set; } = Lorem.Sentence();
    public string Message { get; set; } = Lorem.Paragraph(2);
}