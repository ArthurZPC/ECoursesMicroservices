using ECoursesMicroservices.Infrastructure.Interfaces;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries;
public class GetTagsPagedQuery : PagedQuery, IRequest<PagedResult<TagDto>>
{
    public string? Name { get; set; }
}
