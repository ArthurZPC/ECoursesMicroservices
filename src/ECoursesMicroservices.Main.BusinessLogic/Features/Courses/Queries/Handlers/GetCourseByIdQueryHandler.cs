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
        var course = await _context.Courses
            .Include(x => x.Tags)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<CourseDto>(course);
    }
}
