using AutoMapper;
using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries.Handlers;
public class GetVideoQueryHandler : IRequestHandler<GetVideoQuery, VideoDto>
{
    private readonly ECoursesVideoContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<GetVideoQuery> _validator;

    public GetVideoQueryHandler(ECoursesVideoContext context,
        IMapper mapper,
        IValidator<GetVideoQuery> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<VideoDto> Handle(GetVideoQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var video = await _context.Videos
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id && x.CourseId == request.CourseId);

        return _mapper.Map<VideoDto>(video);
    }
}
