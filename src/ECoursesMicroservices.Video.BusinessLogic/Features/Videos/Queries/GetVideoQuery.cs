using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries;
public class GetVideoQuery : IRequest<VideoDto>
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public Guid CourseId { get; set; }
}
