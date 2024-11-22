using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Categories.Commands;
public class DeleteCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}
