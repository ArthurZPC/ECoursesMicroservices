using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
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
}
