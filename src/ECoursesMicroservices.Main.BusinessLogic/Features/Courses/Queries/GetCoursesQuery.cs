using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries;
public class GetCoursesQuery : IRequest<IEnumerable<CourseDto>>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public Guid? CategoryId { get; set; }
    public List<Guid> TagIds { get; set; } = new List<Guid>();
    public Guid? AuthorId { get; set; }
}
