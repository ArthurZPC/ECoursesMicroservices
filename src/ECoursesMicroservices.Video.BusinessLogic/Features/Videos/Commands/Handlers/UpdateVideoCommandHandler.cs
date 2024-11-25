using AutoMapper;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Commands.Handlers;
public class UpdateVideoCommandHandler : IRequestHandler<UpdateVideoCommand>
{
    private readonly ECoursesVideoContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<UpdateVideoCommand> _validator;

    public UpdateVideoCommandHandler(ECoursesVideoContext context,
        IMapper mapper,
        IValidator<UpdateVideoCommand> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task Handle(UpdateVideoCommand request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var video = await _context.Videos.FirstAsync(x => x.Id == request.Id);

        _mapper.Map(request, video);

        await _context.SaveChangesAsync();
    }
}
