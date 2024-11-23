using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoursesMicroservices.Main.API.Controllers;

[ApiController]
[Route("[controller]")]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> GetTagById(Guid id)
    {
        var tag = await _mediator.Send(new GetTagByIdQuery { Id = id });
        var response = ApiResponseBuilder.Create(tag);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAll([FromQuery] GetTagsQuery query)
    {
        var tags = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(tags);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAllPaged([FromQuery] GetTagsPagedQuery query)
    {
        var tags = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(tags);

        return Ok(response);
    }

    [HttpPost("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Create([FromBody] CreateTagCommand command)
    {
        await _mediator.Send(command);

        return CreatedAtAction(nameof(Create), command);
    }

    [HttpDelete("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Delete([FromBody] DeleteTagCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Update([FromBody] UpdateTagCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
