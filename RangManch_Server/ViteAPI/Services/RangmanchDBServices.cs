
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ViteAPI.Models;

namespace ViteAPI.Services;

public class RangmanchDBServices
{
 private readonly IMongoCollection<Post> _posts;
 
 public RangmanchDBServices(IOptions<RangmanchDBSettings> settings)
 {
     var client = new MongoClient(settings.Value.ConnectionString);
     var database = client.GetDatabase(settings.Value.DatabaseName);
     _posts = database.GetCollection<Post>(settings.Value.CollectionName);
     Console.WriteLine(database);
 }

 //create
    public async Task createAsync(Post newPost)
    {
        await _posts.InsertOneAsync(newPost);
    }
 
 //read
    public async Task<List<Post>> readAsync()
    {
        return await _posts.Find(post => true).ToListAsync();
    }

 //update
    public async Task updateAsync(string id, Post updatedPost)
    {
        await _posts.ReplaceOneAsync(post => post.Id == id, updatedPost);
    }
//delete
    public async Task deleteAsync(string id)
    {
        await _posts.DeleteOneAsync(post => post.Id == id);
    }

//read in range
    public async Task<List<Post>> readInRangeAsync(int skip, int limit)
    {
        return await _posts.Find(post => true).Skip(skip).Limit(limit).ToListAsync();
    }

}