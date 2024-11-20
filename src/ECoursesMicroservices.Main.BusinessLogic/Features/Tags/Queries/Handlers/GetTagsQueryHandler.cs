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
        var tags = GetFilteredQuery(request);;

        return _mapper.Map<IEnumerable<TagDto>>(await tags.ToListAsync());
    }

    private IQueryable<Tag> GetFilteredQuery(GetTagsQuery request)
    {
        var tags = _context.Tags.AsNoTracking();

        if (!string.IsNullOrEmpty(request.Name))
        {
            tags = tags.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }

        return tags;
    }
}
