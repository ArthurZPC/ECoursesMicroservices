using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands;
public class CreateCourseCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public Guid CategoryId { get; set; }
    public Guid AuthorId { get; set; }
    public List<Guid> Tags { get; set; } = new List<Guid>();
}
