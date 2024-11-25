using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
public class UpdateVideoCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public Guid CourseId { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;
}
