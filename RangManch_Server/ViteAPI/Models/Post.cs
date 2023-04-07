using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ViteAPI.Models;

public class Post
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonIgnoreIfNull]
    [BsonElement("Title")]
    
    public string? Title { get; set; }

    [BsonIgnoreIfNull]
    [BsonElement("Files")]
    
    public List<Files>? Files { get; set; }

    [BsonElement("Content")]
    [BsonIgnoreIfNull]
    public string? Content { get; set; }
}

public class Files
{  
    public string? Name { get; set; }
    public string? URL { get; set; }
    public string? ContentType { get; set; }
   
}
public class Tags
{
    public string? Name { get; set; }
    public string? URL { get; set; }
    
}
public class Categories
{
    public string? Name { get; set; }
    public string? URL { get; set; }
    
}
