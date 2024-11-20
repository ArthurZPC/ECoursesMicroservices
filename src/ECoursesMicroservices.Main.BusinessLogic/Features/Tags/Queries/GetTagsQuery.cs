using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries;
public class GetTagsQuery : IRequest<IEnumerable<TagDto>>
{
    public string? Name { get; set; }
}
