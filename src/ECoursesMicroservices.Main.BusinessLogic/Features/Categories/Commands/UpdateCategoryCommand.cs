using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
public class UpdateCategoryCommand : IRequest
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;
}
