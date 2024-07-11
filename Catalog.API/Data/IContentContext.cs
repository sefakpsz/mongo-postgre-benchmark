using ContentMongo.API.Entities;
using MongoDB.Driver;

namespace ContentMongo.API.Data;

public interface IContentContext
{
    IMongoCollection<Content> Contents { get; }
}