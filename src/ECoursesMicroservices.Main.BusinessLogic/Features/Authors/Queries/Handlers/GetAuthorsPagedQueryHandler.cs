using AutoMapper;
using ECoursesMicroservices.Infrastructure.Extensions;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries.Handlers;
public class GetAuthorsPagedQueryHandler : IRequestHandler<GetAuthorsPagedQuery, PagedResult<AuthorDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetAuthorsPagedQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PagedResult<AuthorDto>> Handle(GetAuthorsPagedQuery request, CancellationToken cancellationToken)
    {
        var authors = _context.Authors.AsNoTracking();
        var totalCount = await authors.CountAsync();

        var filteredAuthors = GetFilteredQuery(request, authors);

        var result = await filteredAuthors.ToListAsync();

        return new PagedResult<AuthorDto>
        {
            TotalCount = totalCount,
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            Items = _mapper.Map<List<AuthorDto>>(result)
        };

    }

    private IQueryable<Author> GetFilteredQuery(GetAuthorsPagedQuery request, IQueryable<Author> authors)
    {
        var query = authors;

        if (!string.IsNullOrEmpty(request.FirstName))
        {
            query = query.Where(x => x.FirstName.ToLower().Contains(request.FirstName.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.LastName))
        {
            query = query.Where(x => x.LastName.ToLower().Contains(request.LastName.ToLower()));
        }

        query = query.GetPagedQuery(request.PageSize, request.PageNumber);

        return query;
    }
}
