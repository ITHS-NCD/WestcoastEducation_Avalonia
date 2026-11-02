using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;
using Client.Services;

namespace Client;

public class CourseService : ICourseService
{
    public async Task Add(Course course)
    {
        HttpService<Course> service = new();
        await service.Post("courses", course);
    }

    public async Task Delete(string id)
    {
        HttpService<Course> service = new();
        await service.Delete("courses", id);
    }

    public async Task<CourseRestDb> Find(string id)
    {
        HttpService<CourseRestDb> service = new();
        var searchCriteria = "{\"courseNumber\":\"" + id + "\"}";
        return await service.Get("courses", searchCriteria);
    }

    public Task<List<Course>> List()
    {
        HttpService<Course> service = new();
        var courses = service.Get("courses");
        return courses;
    }

    public async Task Update(Course course, string objectId)
    {
        HttpService<Course> service = new();
        await service.Put("courses", course, objectId);
    }
}
