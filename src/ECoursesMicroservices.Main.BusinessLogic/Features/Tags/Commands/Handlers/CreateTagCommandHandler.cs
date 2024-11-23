using AutoMapper;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands.Handlers;
public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateTagCommand> _validator;

    public CreateTagCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<CreateTagCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var tag = _mapper.Map<Tag>(request);

        _context.Tags.Add(tag);

        await _context.SaveChangesAsync();
    }
}
