using ContentMongo.API.Entities;
using MongoDB.Driver;

namespace ContentMongo.API.Data;

public class ContentContext : IContentContext
{
    public ContentContext(IConfiguration configuration)
    {
        var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));

        Contents = database.GetCollection<Content>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        ContextSeed.SeedData(Contents);
    }

    public IMongoCollection<Content> Contents { get; }
}