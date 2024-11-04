namespace ECoursesMicroservices.Main.Data.Entities;
public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public ICollection<Course> Courses { get; set; } = new List<Course>();
}
