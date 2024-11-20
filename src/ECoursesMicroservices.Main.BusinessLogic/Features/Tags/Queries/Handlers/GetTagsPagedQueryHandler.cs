using AutoMapper;
using ECoursesMicroservices.Infrastructure.Extensions;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries.Handlers;
public class GetTagsPagedQueryHandler : IRequestHandler<GetTagsPagedQuery, PagedResult<TagDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetTagsPagedQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<PagedResult<TagDto>> Handle(GetTagsPagedQuery request, CancellationToken cancellationToken)
    {
        var tags = _context.Tags.AsNoTracking();
        var totalCount = await tags.CountAsync();

        var filteredTags = GetFilteredQuery(request, tags);

        var result = await filteredTags.ToListAsync();

        return new PagedResult<TagDto>
        {
            TotalCount = totalCount,
            PageNumber = request.PageNumber,
            PageSize = request.PageSize,
            Items = _mapper.Map<List<TagDto>>(result)
        };
    }

    private IQueryable<Tag> GetFilteredQuery(GetTagsPagedQuery request, IQueryable<Tag> tags)
    {
        var query = tags;

        if (!string.IsNullOrEmpty(request.Name))
        {
            tags = tags.Where(x => x.Name.ToLower().Contains(request.Name.ToLower()));
        }

        return tags.GetPagedQuery(request.PageSize, request.PageNumber);
    }
}
