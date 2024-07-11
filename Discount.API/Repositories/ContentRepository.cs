using Dapper;
using Discount.API.Entities;
using Npgsql;

namespace Discount.API.Repositories;

public class ContentRepository : IContentRepository
{
    private readonly IConfiguration _configuration;

    public ContentRepository(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }

    public async Task<List<Content>> GetContents()
    {
        using var connection = new NpgsqlConnection(_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));

        var contents = await connection.QueryAsync<Content>("SELECT * FROM Content");

        return contents.ToList();
    }
}