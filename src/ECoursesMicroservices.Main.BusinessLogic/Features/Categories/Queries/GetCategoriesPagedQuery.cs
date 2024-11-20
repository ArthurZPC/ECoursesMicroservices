using ECoursesMicroservices.Infrastructure.Interfaces;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
public class GetCategoriesPagedQuery : PagedQuery, IRequest<PagedResult<CategoryDto>>
{
    public string? Name { get; set; }
}
