using AutoMapper;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Commands.Handlers;
public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateAuthorCommand> _validator;

    public UpdateAuthorCommandHandler(ECoursesContext context,
        IMapper mapper,
        IValidator<UpdateAuthorCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var author = _mapper.Map<Author>(request);

        _context.Entry(author).State = EntityState.Modified;
        _context.Entry(author).Property(x => x.UserId).IsModified = false;

        await _context.SaveChangesAsync();
    }
}
