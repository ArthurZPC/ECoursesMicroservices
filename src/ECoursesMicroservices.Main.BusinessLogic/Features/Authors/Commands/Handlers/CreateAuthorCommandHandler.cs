using AutoMapper;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands.Handlers;
public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateAuthorCommand> _validator;

    public CreateAuthorCommandHandler(ECoursesContext context, 
        IMapper mapper,
        IValidator<CreateAuthorCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var authorToCreate = _mapper.Map<Author>(request);

        _context.Authors.Add(authorToCreate);

        await _context.SaveChangesAsync();
    }
}
