using ContentMongo.API.Data;
using ContentMongo.API.Entities;
using MongoDB.Driver;

namespace ContentMongo.API.Repositories;

public class ContentRepository : IContentRepository
{
    private readonly IContentContext _context;

    public ContentRepository(IContentContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Content>> GetContents()
    {
        return await _context
            .Contents
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<Content> GetContent(string id)
    {
        return await _context
            .Contents
            .Find(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Content>> GetContentByTitle(string title)
    {
        FilterDefinition<Content> filter = Builders<Content>.Filter.ElemMatch(p => p.Title, title);

        return await _context
            .Contents
            .Find(filter)
            .ToListAsync();
    }

    public async Task CreateContent(Content content)
    {
        await _context.Contents.InsertOneAsync(content);
    }

    public async Task<bool> UpdateContent(Content content)
    {
        var updateResult = await _context
            .Contents
            .ReplaceOneAsync(filter: g => g.Id == content.Id, replacement: content);

        return updateResult.IsAcknowledged
               && updateResult.ModifiedCount > 0;
    }

    public async Task<bool> DeleteContent(string id)
    {
        FilterDefinition<Content> filter = Builders<Content>.Filter.Eq(p => p.Id, id);

        DeleteResult deleteResult = await _context
            .Contents
            .DeleteOneAsync(filter);

        return deleteResult.IsAcknowledged
               && deleteResult.DeletedCount > 0;
    }
}