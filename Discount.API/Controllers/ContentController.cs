using System.Net;
using Discount.API.Entities;
using Discount.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Discount.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PostgresContentController : ControllerBase
{
    private readonly IContentRepository _repository;

    public PostgresContentController(IContentRepository repository)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    [HttpGet]
    public async Task<ActionResult<Content>> GetContents()
    {
        var content = await _repository.GetContents();
        return Ok(content);
    }
}