using AutoMapper;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Courses.Commands.Handlers;
public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private IValidator<DeleteCourseCommand> _validator;

    public DeleteCourseCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<DeleteCourseCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var courseToDelete = await _context.Courses.FindAsync(request.Id);

        _context.Courses.Remove(courseToDelete!);

        await _context.SaveChangesAsync();
    }
}
