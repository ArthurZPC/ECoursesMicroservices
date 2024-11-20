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
        var categories = GetFilteredQuery(request);

        return _mapper.Map<List<CategoryDto>>(await categories.ToListAsync());
    }

    private IQueryable<Category> GetFilteredQuery(GetCategoriesQuery request)
    {
        var query = _context.Categories.AsNoTracking();

        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }

        return query;
    }
}
