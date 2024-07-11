using ContentMongo.API.Entities;

namespace ContentMongo.API.Repositories;

public interface IContentRepository
{
    Task<IEnumerable<Content>> GetContents();
    Task<Content> GetContent(string id);
    Task<IEnumerable<Content>> GetContentByTitle(string name);
    Task CreateContent(Content product);
    Task<bool> UpdateContent(Content product);
    Task<bool> DeleteContent(string id);
}