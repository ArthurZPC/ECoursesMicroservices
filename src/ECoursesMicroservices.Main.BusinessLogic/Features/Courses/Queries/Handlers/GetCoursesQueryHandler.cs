using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries.Handlers;
public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<CourseDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetCoursesQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
    {
        var courses = GetFilteredQuery(request);

        return _mapper.Map<List<CourseDto>>(await courses.ToListAsync());
    }

    private IQueryable<Course> GetFilteredQuery(GetCoursesQuery request)
    {
        var courses = _context.Courses.Include(x => x.Tags).AsNoTracking();

        if (!string.IsNullOrEmpty(request.Name))
        {
            courses = courses.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.Description))
        {
            courses = courses.Where(x => x.Description.ToLower().Contains(request.Description.ToLower()));
        }

        if (request.CategoryId.HasValue)
        {
            courses = courses.Where(x => x.CategoryId == request.CategoryId);
        }

        if (request.AuthorId.HasValue)
        {
            courses = courses.Where(x => x.AuthorId == request.AuthorId);
        }

        if (request.TagIds.Count > 0)
        {
            courses = courses.Where(x => x.Tags.Any(y => request.TagIds.Contains(y.Id)));
        }

        return courses;
    }
}
