using System;
using System.Collections.Generic;

namespace Client.Models;

public class Course
{
    public string CourseNumber { get; set; } = Guid.NewGuid().ToString();
    public string CourseTitle { get; set; }
    public required string Length { get; set; }
    public required bool ClassRoom { get; set; }
    public string? Start { get; set; }
    public string? Stop { get; set; }


    public Course(string courseTitle)
    {
        CourseTitle = courseTitle;
    }


}
