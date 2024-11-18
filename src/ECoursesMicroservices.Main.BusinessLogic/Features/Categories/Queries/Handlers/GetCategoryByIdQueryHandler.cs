using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries.Handlers;
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetCategoryByIdQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var categories = _context.Categories.AsNoTracking();
        FilterQuery(request, categories);

        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<CategoryDto>(category);
    }

    private void FilterQuery(GetCategoryByIdQuery request, IQueryable<Category> categories)
    {
        if (request.IncludeChild)
        {
            categories = categories.Include(x => x.Courses);
        }
    }
}
