using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries;
public class GetTagByIdQuery : IRequest<TagDto>
{
    public Guid Id { get; set; }
    public bool IncludeChild { get; set; }
}
