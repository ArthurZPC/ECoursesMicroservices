using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Authors;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Authors.Queries.Handlers;
public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;

    public GetAuthorByIdQueryHandler(ECoursesContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<AuthorDto> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
    {
        var author = await _context.Authors
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<AuthorDto>(author);
    }
}
