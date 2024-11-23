using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Interfaces;
public interface IAuthorService
{
    Task<bool> IsAuthorExists(Guid authorId, CancellationToken token);

    Task<bool> IsAuthorUserIdExists(Guid userId, CancellationToken token);
}
