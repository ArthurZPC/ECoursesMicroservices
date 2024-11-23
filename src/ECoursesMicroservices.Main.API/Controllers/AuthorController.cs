using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands;
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
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetAuthorById(Guid id)
    {
        var author = await _mediator.Send(new GetAuthorByIdQuery { Id = id });
        var response = ApiResponseBuilder.Create(author);

        return Ok(response);
    }

    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetAll([FromQuery] GetAuthorsQuery query)
    {
        var authors = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(authors);

        return Ok(response);
    }

    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetAllPaged([FromQuery] GetAuthorsPagedQuery query)
    {
        var authors = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(authors);

        return Ok(response);
    }

    [HttpPost("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Create([FromBody] CreateAuthorCommand command)
    {
        await _mediator.Send(command);

        return CreatedAtAction(nameof(Create), command);
    }

    [HttpDelete("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Delete([FromBody] DeleteAuthorCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Update([FromBody] UpdateAuthorCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
