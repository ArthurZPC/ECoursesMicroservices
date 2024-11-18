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

        FilterQuery(request, authors);

        var result = await authors.ToListAsync();

        return new PagedResult<AuthorDto>
        {
            TotalCount = totalCount,
            PageSize = request.PageSize,
            PageNumber = request.PageNumber,
            Items = _mapper.Map<List<AuthorDto>>(result)
        };

    }

    private void FilterQuery(GetAuthorsPagedQuery request, IQueryable<Author> authors)
    {
        if (request.IncludeChild)
        {
            authors = authors.Include(x => x.Courses);
        }

        if (!string.IsNullOrEmpty(request.FirstName))
        {
            authors = authors.Where(x => x.FirstName.ToLower().Contains(request.FirstName.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.LastName))
        {
            authors = authors.Where(x => x.LastName.ToLower().Contains(request.LastName.ToLower()));
        }

        authors = authors.GetPagedQuery(request.PageSize, request.PageNumber);
    }
}
