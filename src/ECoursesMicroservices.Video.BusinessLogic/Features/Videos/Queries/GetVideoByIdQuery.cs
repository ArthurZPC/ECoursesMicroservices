using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries;
public class GetVideoByIdQuery : IRequest<VideoDto>
{
    [Required]
    public Guid Id { get; set; }
}
