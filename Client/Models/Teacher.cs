using System.Collections.Generic;
using Client.Services;

namespace Client.Models;

public record Teacher : Student
{
    public List<string>? Knowledge { get; set; }
    public List<Course>? Courses { get; set; }
}
