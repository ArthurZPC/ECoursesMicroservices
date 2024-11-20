using ECoursesMicroservices.Main.BusinessLogic.DTOs.Categories;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Queries;
public class GetCategoryByIdQuery : IRequest<CategoryDto>
{
    public Guid Id { get; set; }
}
