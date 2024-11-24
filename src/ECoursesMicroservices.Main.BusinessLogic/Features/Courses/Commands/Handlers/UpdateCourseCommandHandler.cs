using AutoMapper;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands.Handlers;
public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateCourseCommand> _validator;

    public UpdateCourseCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<UpdateCourseCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var course = await _context.Courses
            .Include(x => x.Tags)
            .FirstAsync(x => x.Id == request.Id);

        var courseTags = await _context.Tags
            .Where(x => request.Tags.Contains(x.Id))
            .ToListAsync();

        _mapper.Map(request, course);

        course!.Tags = courseTags;

        await _context.SaveChangesAsync();
    }
}
