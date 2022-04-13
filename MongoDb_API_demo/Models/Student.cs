using MongoDB.Bson.Serialization.Attributes;

namespace MongoDb_API_demo.Models;

public class Student
{
    public Student()
    {
        Group = new Group();
    }
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }
}
