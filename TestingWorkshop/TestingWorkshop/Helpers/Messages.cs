using System.Collections.Generic;

namespace TestingWorkshop.Helpers;

internal class Messages
{
    public static string AlreadyBookedErrorMessage = "The room dates are either invalid or are already booked for one or more of the dates that you have selected.";

    public static List<string> FormErrorMessages = new()
    {
        "size must be between 3 and 30",
        "must not be null", "must not be empty",
        "size must be between 3 and 18", "must not be null",
        "Lastname should not be blank","Firstname should not be blank",
        "size must be between 11 and 21", "must not be empty"
    };

    public static List<string> ContactFormEmptyFieldsErrorMessages = new()
    {
        "Phone may not be blank",
        "Name may not be blank",
        "Subject may not be blank",
        "Message must be between 20 and 2000 characters.",
        "Message may not be blank",
        "Subject must be between 5 and 100 characters.",
        "Phone must be between 11 and 21 characters.",
        "Email may not be blank"
    };

    public static List<string> ContactFormInvalidDataErrorMessages = new()
    {
        "Message must be between 20 and 2000 characters.",
        "Subject must be between 5 and 100 characters.",
        "Phone must be between 11 and 21 characters.",
        "must be a well-formed email address"
    };
}