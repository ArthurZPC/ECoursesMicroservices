using ECoursesMicroservices.Infrastructure.Interfaces;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries;
public class GetCoursesPagedQuery : IRequest<PagedResult<CourseDto>>, IPagedRequest
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? CategoryId { get; set; }
    public List<Guid> TagIds { get; set; } = new List<Guid>();
    public Guid? AuthorId { get; set; }
    public bool IncludeChild { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
