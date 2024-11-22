using AutoMapper;
using ECoursesMicroservices.Infrastructure.Extensions;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries.Handlers;
public class GetCoursesPagedQueryHandler : IRequestHandler<GetCoursesPagedQuery, PagedResult<CourseDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<GetCoursesPagedQuery> _validator;

    public GetCoursesPagedQueryHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<GetCoursesPagedQuery> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<PagedResult<CourseDto>> Handle(GetCoursesPagedQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var courses = _context.Courses.Include(x => x.Tags).AsNoTracking();
        var totalCount = await courses.CountAsync();

        var filteredCourses = GetFilteredQuery(request, courses);

        var result = await filteredCourses.ToListAsync();

        return new PagedResult<CourseDto>
        {
            TotalCount = totalCount,
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            Items = _mapper.Map<List<CourseDto>>(result)
        };
    }

    private IQueryable<Course> GetFilteredQuery(GetCoursesPagedQuery request, IQueryable<Course> courses)
    {
        var query = courses;

        if (!string.IsNullOrEmpty(request.Name))
        {
            query = query.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.Description))
        {
            query = query.Where(x => x.Description.ToLower().Contains(request.Description.ToLower()));
        }

        if (request.CategoryId.HasValue)
        {
            query = query.Where(x => x.CategoryId == request.CategoryId);
        }

        if (request.AuthorId.HasValue)
        {
            query = query.Where(x => x.AuthorId == request.AuthorId);
        }

        if (request.TagIds.Count > 0)
        {
            query = query.Where(x => x.Tags.Any(y => request.TagIds.Contains(y.Id)));
        }

        return query.GetPagedQuery(request.PageSize, request.PageNumber);
    }
}
