using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.Data;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Services;
public class CourseService : ICourseService
{
    private readonly ECoursesContext _context;

    public CourseService(ECoursesContext context)
    {
        _context = context;
    }

    public async Task<bool> IsCourseExists(Guid courseId, CancellationToken token)
    {
        return await _context.Courses.AnyAsync(x => x.Id == courseId);
    }
}
