using ContentMongo.API.Data;
using ContentMongo.API.Entities;
using ContentMongo.API.Repositories;

namespace Catalog.API.GraphQL
{
    public class Query
    {
        public async Task<IEnumerable<Content>> GetContents([Service] IContentRepository context)
        {
            return await context.GetContents();
        }
    }
}