using MediatR;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands;
public class CreateVideoCommand : IRequest
{
    [Required]
    public Guid CourseId { get; set; }

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    [JsonIgnore]
    public IFormFile PreviewImage { get; set; } = null!;

    [Required]
    [JsonIgnore]
    public IFormFile Video { get; set; } = null!;
}
