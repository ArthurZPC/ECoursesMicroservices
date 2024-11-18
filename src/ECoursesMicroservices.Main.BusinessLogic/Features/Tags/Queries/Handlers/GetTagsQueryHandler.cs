using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries.Handlers;
public class GetTagsQueryHandler : IRequestHandler<GetTagsQuery, IEnumerable<TagDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetTagsQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<IEnumerable<TagDto>> Handle(GetTagsQuery request, CancellationToken cancellationToken)
    {
        var tags = _context.Tags.AsNoTracking();
        FilterQuery(request, tags);;

        return _mapper.Map<IEnumerable<TagDto>>(await tags.ToListAsync());
    }

    private void FilterQuery(GetTagsQuery request, IQueryable<Tag> tags)
    {
        if (request.IncludeChild)
        {
            tags = tags.Include(x => x.Courses);
        }

        if (!string.IsNullOrEmpty(request.Name))
        {
            tags = tags.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }
    }
}
