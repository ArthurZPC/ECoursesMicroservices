using AutoMapper;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using ECoursesMicroservices.Main.Data;
using ECoursesMicroservices.Main.Data.Entities;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries.Handlers;
public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto>
{
    private readonly ECoursesContext _context;
    private readonly IMapper _mapper;
    private readonly IValidator<GetCategoryByIdQuery> _queryValidator;

    public GetCategoryByIdQueryHandler(ECoursesContext context, 
        IMapper mapper,
        IValidator<GetCategoryByIdQuery> queryValidator)
    {
        _context = context;
        _mapper = mapper;
        _queryValidator = queryValidator;
    }

    public async Task<CategoryDto> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        await _queryValidator.ValidateAndThrowAsync(request, cancellationToken);

        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        return _mapper.Map<CategoryDto>(category);
    }
}
