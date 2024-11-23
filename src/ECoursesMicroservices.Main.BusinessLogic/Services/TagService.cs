using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.Data;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Services;
public class TagService : ITagService
{
    private readonly ECoursesContext _context;

    public TagService(ECoursesContext context)
    {
        _context = context;
    }

    public async Task<bool> AreTagsExists(List<Guid> tags, CancellationToken cancellationToken)
    {
        var existingTagCount = await _context.Tags
            .AsNoTracking()
            .CountAsync(x => tags.Contains(x.Id));

        return existingTagCount == tags.Count;
    }

    public async Task<bool> IsTagExists(Guid tagId, CancellationToken cancellationToken)
    {
        return await _context.Tags.AnyAsync(x => x.Id == tagId);
    }

    public async Task<bool> IsTagExists(string tagName, CancellationToken cancellationToken)
    {
        return await _context.Tags.AnyAsync(x => x.Name == tagName);
    }
}
