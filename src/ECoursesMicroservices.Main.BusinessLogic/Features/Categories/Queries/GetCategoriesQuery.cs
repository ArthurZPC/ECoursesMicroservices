using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
public class GetCategoriesByNameQuery : IRequest<IEnumerable<CategoryDto>>
{
    public string? Name { get; set; }
    public bool IncludeChild { get; set; }
}
