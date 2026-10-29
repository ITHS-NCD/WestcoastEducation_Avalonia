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

    public Task Delete(string id)
    {
        throw new System.NotImplementedException();
    }

    public Task<List<Student>> List()
    {
        HttpService<Student> service = new();
        var students = service.Get("students");
        return students;
    }

    public async Task Update(Student student, string _objectId)
    {
        HttpService<Student> service = new();
        await service.Put("students", student, _objectId);
    }
}
