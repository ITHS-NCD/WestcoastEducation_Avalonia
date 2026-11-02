using System.Collections.Generic;
using System.Threading.Tasks;
using Client.Interfaces;
using Client.Models;

namespace Client.Services;

public class TeacherService : ITeacherService
{
    public async Task Add(Teacher teacher)
    {
        HttpService<Teacher> service = new();
        await service.Post("teachers", teacher);
    }

    public async Task Delete(string id)
    {
        HttpService<Teacher> service = new();
        await service.Delete("teachers", id);
    }

    public async Task<TeacherRestDb> Find(string id)
    {
        HttpService<TeacherRestDb> service = new();
        var searchCriteria = "{\"id\":\"" + id + "\"}";
        return await service.Get("teachers", searchCriteria);
    }

    public Task<List<Teacher>> List()
    {
        HttpService<Teacher> service = new();
        return service.Get("teachers");

    }

    public async Task Update(Teacher teacher, string objectId)
    {
        HttpService<Teacher> service = new();
        await service.Put("teachers", teacher, objectId);
    }
}
