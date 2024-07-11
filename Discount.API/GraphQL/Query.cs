
using Discount.API.Context;
using Discount.API.Entities;

namespace Discount.API.GraphQL
{
    public class Query
    {
        [UseDbContext(typeof(ContentDbContext))]
        [UseProjection]
        public IQueryable<Content> GetContents([ScopedService] ContentDbContext context)
        {
            return context.content;
        }
    }
}