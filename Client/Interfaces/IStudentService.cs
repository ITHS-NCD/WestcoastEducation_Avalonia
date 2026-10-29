using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Models;

namespace Client.Interfaces;

public interface IStudentService
{
    Task Add(Student student);
    Task Delete(string id);
    Task<StudentRestDb> Find(string id);
    Task<List<Student>> List();
    Task Update(Student student, string _objectId);
}
