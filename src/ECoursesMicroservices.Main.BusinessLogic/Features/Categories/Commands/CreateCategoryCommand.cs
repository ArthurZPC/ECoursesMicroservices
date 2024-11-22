using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
public class CreateCategoryCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
}
