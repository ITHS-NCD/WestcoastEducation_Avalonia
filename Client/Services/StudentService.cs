using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class StudentService : IStudentService
{
    public async Task Add(Student student)
    {
        HttpService<Student> service = new();
        await service.Post("students", student);
    }

    public async Task Delete(string id)
    {
        HttpService<Student> service = new();
        await service.Delete("students", id);
    }

    public async Task<StudentRestDb> Find(string id)
    {
        HttpService<StudentRestDb> service = new();
        var searchCriteria = "{\"id\":\"" + id + "\"}";
        return await service.Get("students", searchCriteria);
    }

    public Task<List<Student>> List()
    {
        HttpService<Student> service = new();
        var students = service.Get("students");
        return students;
    }

    public async Task Update(Student student, string objectId)
    {
        HttpService<Student> service = new();
        await service.Put("students", student, objectId);
    }
}
