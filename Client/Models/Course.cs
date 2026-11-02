using System;
using System.Collections.Generic;

namespace Client.Models;

public record Course
{
    public string CourseNumber { get; set; } = Guid.NewGuid().ToString();
    public required string CourseTitle { get; set; }
    public required string Length { get; set; }
    public required bool ClassRoom { get; set; }
    public string? Start { get; set; }
    public string? End { get; set; }
    public List<Student>? Students { get; set; }
    public string CourseType => ClassRoom ? "Klassrum" : "Distans";

}
