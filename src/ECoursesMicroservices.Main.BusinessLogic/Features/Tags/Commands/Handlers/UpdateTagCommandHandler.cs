using AutoMapper;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Commands.Handlers;
public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateTagCommand> _validator;

    public UpdateTagCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<UpdateTagCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }
    public async Task Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var tag = _mapper.Map<Tag>(request);

        _context.Entry(tag).State = EntityState.Modified;

        await _context.SaveChangesAsync();
    }
}
