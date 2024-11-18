using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries.Handlers;
public class GetTagByIdQueryHandler : IRequestHandler<GetTagByIdQuery, TagDto>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetTagByIdQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<TagDto> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var tags = _context.Tags.AsNoTracking();
        FilterQuery(request, tags);

        var tag = await tags.FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<TagDto>(tag);
    }

    private void FilterQuery(GetTagByIdQuery request, IQueryable<Tag> tags)
    {
        if (request.IncludeChild)
        {
            tags = tags.Include(x => x.Courses);
        }
    }
}
