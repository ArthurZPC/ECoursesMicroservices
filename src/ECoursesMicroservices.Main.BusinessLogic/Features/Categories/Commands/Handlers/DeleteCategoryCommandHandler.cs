using AutoMapper;
using ECoursesMicroservices.Main.Data;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands.Handlers;
public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<DeleteCategoryCommand> _validator;

    public DeleteCategoryCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<DeleteCategoryCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var categoryToDelete = await _context.Categories.FindAsync(request.Id);

        _context.Categories.Remove(categoryToDelete!);

        await _context.SaveChangesAsync();
    }
}
