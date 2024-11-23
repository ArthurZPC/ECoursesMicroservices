using AutoMapper;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands.Handlers;
public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateCategoryCommand> _validator;

    public CreateCategoryCommandHandler(ECoursesContext context, 
        IMapper mapper,
        IValidator<CreateCategoryCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var category = _mapper.Map<Category>(request);

        _context.Categories.Add(category);

        await _context.SaveChangesAsync();
    }
}
