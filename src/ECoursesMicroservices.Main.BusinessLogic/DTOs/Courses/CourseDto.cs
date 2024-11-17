using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;

namespace ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
public class CourseDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }

    public CategoryDto Category { get; set; } = null!;
    public AuthorDto Author { get; set; } = null!;

    public List<TagDto> Tags { get; set; } = new List<TagDto>();
}
