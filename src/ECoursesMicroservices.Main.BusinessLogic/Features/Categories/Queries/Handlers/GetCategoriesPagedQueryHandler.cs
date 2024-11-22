using AutoMapper;
using ECoursesMicroservices.Infrastructure.Extensions;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries.Handlers;
public class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, PagedResult<CategoryDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<GetCategoriesPagedQuery> _validator;

    public GetCategoriesPagedQueryHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<GetCategoriesPagedQuery> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<PagedResult<CategoryDto>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var categories = _context.Categories.AsNoTracking();
        var totalCount = await categories.CountAsync();

        var filteredCategories = GetFilteredQuery(request, categories);

        var result = await filteredCategories.ToListAsync();

        return new PagedResult<CategoryDto>
        {
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            Items = _mapper.Map<List<CategoryDto>>(result),          
        };
    }

    private IQueryable<Category> GetFilteredQuery(GetCategoriesPagedQuery request, IQueryable<Category> categories)
    {
        var resultQuery = categories;

        if (!string.IsNullOrEmpty(request.Name))
        {
            resultQuery = resultQuery.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }

        return resultQuery.GetPagedQuery(request.PageSize, request.PageNumber);
    }
}
