using MongoDb_API_demo.Models;

namespace MongoDb_API_demo.Services;

public interface IStudentService
{
    Task<List<Student>> GetAll();
    Task<List<Student>> GetById(string id);
    Task<Student> Add(Student student);
    Task<Student> Update(Student student);
    Task<bool> Delete(string id);
}
