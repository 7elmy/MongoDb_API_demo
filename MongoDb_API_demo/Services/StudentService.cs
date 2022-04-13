using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDb_API_demo.Models;

namespace MongoDb_API_demo.Services;

public class StudentService : IStudentService
{
    private readonly IMongoCollection<Student> _students;
    public StudentService(IMongoClient mongoClient, IOptions<DBSettigs> options)
    {
        _students = mongoClient.GetDatabase(options.Value.DatabaseName)
            .GetCollection<Student>(nameof(Student));
    }
    public async Task<Student> Add(Student student)
    {
        await _students.InsertOneAsync(student);
        return student;
    }

    public async Task<List<Student>> GetAll()
    => await _students.Find(_ => true).ToListAsync();

    public async Task<List<Student>> GetById(string id)
    => await _students.Find(student => student.Id == id).ToListAsync();

    public async Task<Student> Update(Student student)
    {
        await _students.ReplaceOneAsync(m => m.Id == student.Id, student);
        return student;
    }
    public async Task<bool> Delete(string id)
    {
        var deletedRes = await _students.DeleteOneAsync(m => m.Id == id);
        return deletedRes.DeletedCount > 0;
    }

}
