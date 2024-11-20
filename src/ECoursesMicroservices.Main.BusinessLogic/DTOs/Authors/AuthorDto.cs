using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;

namespace ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
public class AuthorDto
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
