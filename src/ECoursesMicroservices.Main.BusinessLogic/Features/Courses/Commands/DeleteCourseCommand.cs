using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
public class DeleteCourseCommand : IRequest
{
    public Guid Id { get; set; }
}
