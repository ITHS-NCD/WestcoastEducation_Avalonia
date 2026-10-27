using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class StudentService : IStudentService
{
    public Task Add(Student student)
    {
        throw new System.NotImplementedException();
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

    public Task Update(Student student, string _objektId)
    {
        throw new System.NotImplementedException();
    }
}
