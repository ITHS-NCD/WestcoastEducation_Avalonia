using Client.Interfaces;
using Client.Services;

namespace Client.Models;

public class Student : IPerson
{

    public string PersonNumber { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required Address Address { get; set; }

    public Student(string personNumber)
    {
        PersonNumber = personNumber;
    }

}



