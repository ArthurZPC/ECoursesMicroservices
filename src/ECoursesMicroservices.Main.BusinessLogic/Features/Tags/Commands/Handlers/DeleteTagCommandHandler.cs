using AutoMapper;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands.Handlers;
public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteTagCommand> _validator;

    public DeleteTagCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<DeleteTagCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var tagToDelete = await _context.Tags.FindAsync(request.Id);

        _context.Tags.Remove(tagToDelete!);

        await _context.SaveChangesAsync();
    }
}
