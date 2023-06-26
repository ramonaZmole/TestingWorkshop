using System.Collections.Generic;
using TestingWorkshop.Helpers;
using TestingWorkshop.Helpers.Models;

namespace TestingWorkshop.Tests;

[TestClass]
public class ContactFormTests : BaseTest
{
    private static readonly ContactForm EmptyData = new()
    {
        Email = string.Empty,
        Name = string.Empty,
        Phone = string.Empty,
        Message = string.Empty,
        Subject = string.Empty
    };

    private static readonly ContactForm InvalidData = new()
    {
        Email = RandomNumber.Next(50).ToString(),
        Name = RandomNumber.Next(50).ToString(),
        Phone = RandomNumber.Next(50).ToString(),
        Message = RandomNumber.Next(50).ToString(),
        Subject = RandomNumber.Next(50).ToString()
    };

    public static IEnumerable<object[]> ContactForm()
    {
        yield return new object[] { EmptyData, Messages.ContactFormEmptyFieldsErrorMessages };
        yield return new object[] { InvalidData, Messages.ContactFormInvalidDataErrorMessages };
    }

    [DynamicData(nameof(ContactForm), DynamicDataSourceType.Method)]
    [TestMethod]
    public void WhenSendingMessageWithInvalidData_ErrorShouldBeReturned(ContactForm formData, List<string> errorMessages)
    {
        Browser.GoTo(Constants.Url);

        Pages.Homepage.SendMessage(formData);

        Pages.Homepage.GetErrorMessages().Should().BeEquivalentTo(errorMessages);
    }
}