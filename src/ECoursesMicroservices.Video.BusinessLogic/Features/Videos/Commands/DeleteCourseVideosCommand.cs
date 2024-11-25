using MediatR;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
public class DeleteCourseVideosCommand : IRequest
{
    public Guid CourseId { get; set; }
}
