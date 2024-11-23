using ECoursesMicroservices.Main.BusinessLogic.Interfaces;
using ECoursesMicroservices.Main.Data;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Services.ValidationServices;
public class CategoryService : ICategoryService
{
    private readonly ECoursesContext _context;

    public CategoryService(ECoursesContext context)
    {
        _context = context;
    }

    public async Task<bool> IsCategoryExists(Guid categoryId, CancellationToken token)
    {
        return await _context.Categories.AnyAsync(x => x.Id == categoryId);
    }

    public async Task<bool> IsCategoryExists(string categoryName, CancellationToken token)
    {
        return await _context.Categories.AnyAsync(x => x.Name == categoryName);
    }
}
