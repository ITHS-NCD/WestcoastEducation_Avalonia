using System;

namespace Client.Models;

public class StudentRestDb(string personNo) : Student(personNo)
{
    public string _id { get; set; } = string.Empty;
}
