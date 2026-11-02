using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

public interface ICourseService
{
    Task Add(Course course);
    Task Delete(string id);
    Task<CourseRestDb> Find(string id);
    Task<List<Course>> List();
    Task Update(Course course, string objectId);
}
