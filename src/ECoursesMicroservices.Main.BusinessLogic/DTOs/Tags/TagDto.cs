using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;

namespace ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
public class TagDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<CourseDto> Courses { get; set; } = new List<CourseDto>();
}
