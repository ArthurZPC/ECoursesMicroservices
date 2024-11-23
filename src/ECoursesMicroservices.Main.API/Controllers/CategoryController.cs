using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
using ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoursesMicroservices.Main.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:Guid}")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetCategoryById(Guid id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        var response = ApiResponseBuilder.Create(category);

        return Ok(response);
    }

    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetAll([FromQuery] GetCategoriesQuery query)
    {
        var categories = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(categories);

        return Ok(response);
    }

    [HttpGet("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> GetAllPaged([FromQuery] GetCategoriesPagedQuery query)
    {
        var categories = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(categories);

        return Ok(response);
    }


    [HttpPost("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Create([FromBody] CreateCategoryCommand command)
    {
        await _mediator.Send(command);

        return CreatedAtAction(nameof(Create), command);
    }

    [HttpDelete("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Delete([FromBody] DeleteCategoryCommand command)
    {
        await _mediator.Send(command);

        return NoContent();
    }

    [HttpPut("[action]")]
    [ProducesDefaultResponseType(typeof(ApiResponse<string>))]
    public async Task<ActionResult> Update([FromBody] UpdateCategoryCommand command)
    {
        await _mediator.Send(command);

        return Ok();
    }
}
