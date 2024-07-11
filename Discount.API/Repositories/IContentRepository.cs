using Discount.API.Entities;

namespace Discount.API.Repositories;

public interface IContentRepository
{
    Task<List<Content>> GetContents();
}