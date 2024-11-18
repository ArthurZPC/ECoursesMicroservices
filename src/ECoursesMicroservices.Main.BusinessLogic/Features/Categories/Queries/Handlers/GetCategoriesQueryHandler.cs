using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries.Handlers;
public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = _context.Categories.AsNoTracking();
        FilterQuery(request, categories);

        return _mapper.Map<List<CategoryDto>>(await categories.ToListAsync());
    }

    private void FilterQuery(GetCategoriesQuery request, IQueryable<Category> categories)
    {
        if (request.IncludeChild)
        {
            categories = categories.Include(x => x.Courses);
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            categories.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }
    }
}
