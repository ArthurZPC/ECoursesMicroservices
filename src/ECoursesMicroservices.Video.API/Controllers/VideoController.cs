using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Video.API.Settings;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
using ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ECoursesMicroservices.Video.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VideoController : ControllerBase
{
    private readonly IMediator _mediator;

    public VideoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("[action]/{id:guid}")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetVideoById(Guid id)
    {
        var video = await _mediator.Send(new GetVideoByIdQuery() { Id = id });
        var response = ApiResponseBuilder.Create(video);

        return Ok(response);
    }

    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetVideoById([FromQuery] GetVideoQuery query)
    {
        var video = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(video);

        return Ok(response);
    }

    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetVideosByCourseId([FromQuery] GetVideosByCourseIdQuery query)
    {
        var videos = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(videos);

        return Ok(response);
    }

    [HttpPost("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Create(CreateVideoCommand command)
    {
        await _mediator.Send(command);

        return CreatedAtAction(nameof(Create), ApiResponseBuilder.Create(command));
    }

    [HttpPut("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Update([FromBody] UpdateVideoCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }

    [HttpDelete("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Delete([FromBody] DeleteVideoCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

}
