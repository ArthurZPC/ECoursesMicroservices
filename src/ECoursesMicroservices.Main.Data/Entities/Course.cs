namespace ECoursesMicroservices.Main.Data.Entities;
public class Course
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public Guid AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public Guid CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
