using System.Net;
using ContentMongo.API.Entities;
using ContentMongo.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ContentMongo.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MongoContentController : ControllerBase
{
    private readonly IContentRepository _repository;
    private readonly ILogger<MongoContentController> _logger;

    public MongoContentController(IContentRepository repository, ILogger<MongoContentController> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Content>>> GetContents()
    {
        var products = await _repository.GetContents();
        return Ok(products);
    }
}