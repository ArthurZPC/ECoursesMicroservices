using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries;
public class GetVideosByCourseIdQuery : IRequest<IEnumerable<VideoDto>>
{
    [Required]
    public Guid CourseId { get; set; }
}
