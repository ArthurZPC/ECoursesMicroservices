using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries;
public class GetCourseByIdQuery : IRequest<CourseDto>
{
    public Guid Id { get; set; }
}
