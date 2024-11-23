namespace ECoursesMicroservices.Main.BusinessLogic.Interfaces;
public interface ITagService
{
    Task<bool> IsTagExists(Guid tagId, CancellationToken cancellationToken);
    Task<bool> IsTagExists(string tagName, CancellationToken cancellationToken);
    Task<bool> AreTagsExists(List<Guid> tags, CancellationToken cancellationToken);

}
