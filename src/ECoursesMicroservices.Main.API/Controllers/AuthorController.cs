using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoursesMicroservices.Main.API.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthorController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> GetAuthorById(Guid id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery { Id = id });
        var response = ApiResponseBuilder.Create(author);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAll([FromQuery] GetAuthorsQuery query)
    {
        var authors = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(authors);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAllPaged([FromQuery] GetAuthorsPagedQuery query)
    {
        var authors = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(authors);

        return Ok(response);
    }
}
