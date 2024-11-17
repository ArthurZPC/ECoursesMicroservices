using ECoursesMicroservices.Infrastructure.Interfaces;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
public class GetCategoriesPagedQuery : IRequest<PagedResult<CategoryDto>>, IPagedRequest
{
    public string? Name { get; set; }
    public bool IncludeChild { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
