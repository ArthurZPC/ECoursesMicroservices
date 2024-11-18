using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries.Handlers;
public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetCourseByIdQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        var courses = _context.Courses.AsNoTracking();
        FilterQuery(request, courses);

        var course = await courses.FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<CourseDto>(course);
    }

    private void FilterQuery(GetCourseByIdQuery request, IQueryable<Course> courses)
    {
        if (request.IncludeChild)
        {
            courses = courses
                .Include(x => x.Author)
                .Include(x => x.Category)
                .Include(x => x.Tags);
        }
    }
}
