using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Courses;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Queries.Handlers;
public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseDto>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<GetCourseByIdQuery> _validator;

    public GetCourseByIdQueryHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<GetCourseByIdQuery> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<CourseDto> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var course = await _context.Courses
            .Include(x => x.Tags)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<CourseDto>(course);
    }
}
