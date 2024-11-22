using ECoursesMicroservices.Infrastructure.Helpers;
using ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECoursesMicroservices.Main.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CourseController : ControllerBase
{
    private readonly IMediator _mediator;

    public CourseController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id:Guid}")]
    public async Task<ActionResult> GetCourseById(Guid id)
    {
        var course = await _mediator.Send(new GetCourseByIdQuery { Id = id });
        var response = ApiResponseBuilder.Create(course);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAll([FromQuery] GetCoursesQuery query)
    {
        var courses = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(courses);

        return Ok(response);
    }

    [HttpGet("[action]")]
    public async Task<ActionResult> GetAllPaged([FromQuery] GetCoursesPagedQuery query)
    {
        var courses = await _mediator.Send(query);
        var response = ApiResponseBuilder.Create(courses);

        return Ok(response);
    }
}
