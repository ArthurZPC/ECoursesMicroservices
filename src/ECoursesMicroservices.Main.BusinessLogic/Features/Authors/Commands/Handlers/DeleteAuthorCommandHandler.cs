using AutoMapper;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands.Handlers;
public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteAuthorCommand> _validator;

    public DeleteAuthorCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<DeleteAuthorCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request);

        var authorToDelete = await _context.Authors.FindAsync(request.Id);

        _context.Authors.Remove(authorToDelete!);
        
        await _context.SaveChangesAsync();
    }
}
