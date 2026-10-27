using Client.Services;

namespace Client.Models;

public class Teacher(string personNumber) : Student(personNumber)
{
    public string? Knowledge { get; set; }
    public string? Responsibility { get; set; }


}
