namespace ECoursesMicroservices.Video.BusinessLogic.DTOs;
public class VideoDto
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string PreviewImageUrl { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}
