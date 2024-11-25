using AutoMapper;
using ECoursesMicroservices.Video.BusinessLogic.DTOs;
using ECoursesMicroservices.Video.Data;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.BusinessLogic.Features.Videos.Queries.Handlers;
public class GetVideosByCourseIdQueryHandler : IRequestHandler<GetVideosByCourseIdQuery, IEnumerable<VideoDto>>
{
    private readonly ECoursesVideoContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<GetVideosByCourseIdQuery> _validator;

    public GetVideosByCourseIdQueryHandler(ECoursesVideoContext context,
        IMapper mapper,
        IValidator<GetVideosByCourseIdQuery> validator)
    {
        _context = context;
        _mapper = mapper;
        _validator = validator;
    }

    public async Task<IEnumerable<VideoDto>> Handle(GetVideosByCourseIdQuery request, CancellationToken cancellationToken)
    {
        await _validator.ValidateAndThrowAsync(request, cancellationToken);

        var videos = await _context.Videos
            .Where(x => x.CourseId == request.CourseId)
            .ToListAsync();

        return _mapper.Map<List<VideoDto>>(videos);
    }
}
