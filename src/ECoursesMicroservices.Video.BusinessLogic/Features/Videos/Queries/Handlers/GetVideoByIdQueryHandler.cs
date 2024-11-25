using AutoMapper;
using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries.Handlers;
public class GetVideoByIdQueryHandler : IRequestHandler<GetVideoByIdQuery, VideoDto>
{
    private readonly ECoursesVideoContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<GetVideoByIdQuery> _validator;

    public GetVideoByIdQueryHandler(ECoursesVideoContext context,
        IMapper mapper,
        IValidator<GetVideoByIdQuery> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<VideoDto> Handle(GetVideoByIdQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var video = await _context.Videos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<VideoDto>(video);
    }
}
