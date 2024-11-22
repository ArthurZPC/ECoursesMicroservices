using ECoursesMicroservices.Infrastructure.Helpers;
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
    public async Task<ActionResult> GetCategoryById(Guid id)
    {
        var category = await _mediator.Send(new GetCategoryByIdQuery { Id = id });
        var response = ApiResponseBuilder.Create(category);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAll([FromQuery] GetCategoriesQuery query)
    {
        var categories = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(categories);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAllPaged([FromQuery] GetCategoriesPagedQuery query)
    {
        var categories = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(categories);

        return Ok(response);
    }
}
