using AutoMapper;
using ECoursesMicroservices.Infrastructure.Extensions;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries.Handlers;
public class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, PagedResult<CategoryDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetCategoriesPagedQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResult<CategoryDto>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
    {
        var categories = _context.Categories.AsNoTracking();
        var totalCount = await categories.CountAsync();

        FilterQuery(request, categories);

        var result = await categories.ToListAsync();

        return new PagedResult<CategoryDto>
        {
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            Items = _mapper.Map<List<CategoryDto>>(result),          
        };
    }

    private void FilterQuery(GetCategoriesPagedQuery request, IQueryable<Category> categories)
    {
        if (request.IncludeChild)
        {
            categories = categories.Include(x => x.Courses);
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            categories.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }

        categories = categories.GetPagedQuery(request.PageSize, request.PageNumber);
    }
}
