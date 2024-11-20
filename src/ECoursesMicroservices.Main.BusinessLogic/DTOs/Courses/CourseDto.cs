using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;

namespace ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
public class CourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }

    public Guid CategoryId { get; set; }
    public Guid AuthorId { get; set; }

    public List<TagDto> Tags { get; set; } = new List<TagDto>();
}
