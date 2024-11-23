using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.Data;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Services;
public class AuthorService : IAuthorService
{
    private readonly ECoursesContext _context;

    public AuthorService(ECoursesContext context)
    {
        _context = context;
    }

    public async Task<bool> IsAuthorExists(Guid authorId, CancellationToken token)
    {
        return await _context.Authors.AnyAsync(x => x.Id == authorId);
    }

    public async Task<bool> IsAuthorUserIdExists(Guid userId, CancellationToken token)
    {
        return await _context.Authors.AnyAsync(x => x.UserId == userId);
    }
}
