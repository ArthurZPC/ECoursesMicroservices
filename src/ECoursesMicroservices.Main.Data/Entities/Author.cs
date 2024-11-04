namespace ECoursesMicroservices.Main.Data.Entities;
public class Author
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
