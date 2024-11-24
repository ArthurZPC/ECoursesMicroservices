using AutoMapper;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands.Handlers;
public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCourseCommand> _validator;

    public CreateCourseCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<CreateCourseCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var course = _mapper.Map<Course>(request);
        var courseTags = await _context.Tags.Where(x => request.Tags.Contains(x.Id)).ToListAsync();

        foreach (var tag in courseTags)
        {
            course.Tags.Add(tag);
        }

        _context.Attach(course);
        await _context.SaveChangesAsync();
    }
}
