using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;

namespace ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
public class CategoryDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
