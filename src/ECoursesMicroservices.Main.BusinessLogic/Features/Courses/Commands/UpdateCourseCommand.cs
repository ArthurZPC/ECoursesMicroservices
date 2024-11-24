using MediatR;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
public class UpdateCourseCommand : IRequest
{
    [Required]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public DateTime PublishDate { get; set; }

    [Required]
    public Guid CategoryId { get; set; }

    [Required]
    public Guid AuthorId { get; set; }

    public List<Guid> Tags { get; set; } = new List<Guid>();
}
