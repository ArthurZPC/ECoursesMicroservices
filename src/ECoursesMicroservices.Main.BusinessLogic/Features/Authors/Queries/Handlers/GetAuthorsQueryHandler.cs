using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries.Handlers;
public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, IEnumerable<AuthorDto>>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetAuthorsQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = _context.Authors.AsNoTracking();
        FilterQuery(request, authors);

        return _mapper.Map<List<AuthorDto>>(await authors.ToListAsync());
    }

    private void FilterQuery(GetAuthorsQuery request, IQueryable<Author> authors)
    {
        if (request.IncludeChild)
        {
            authors = authors.Include(x => x.Courses);
        }

        if (!string.IsNullOrEmpty(request.FirstName))
        {
            authors.Where(x => x.FirstName.ToLower().Contains(request.FirstName.ToLower()));
        }

        if (!string.IsNullOrEmpty(request.LastName))
        {
            authors.Where(x => x.LastName.ToLower().Contains(request.LastName.ToLower()));
        }
    }
}
