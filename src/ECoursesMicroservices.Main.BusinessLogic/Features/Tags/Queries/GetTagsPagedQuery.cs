using ECoursesMicroservices.Infrastructure.Interfaces;
using ECoursesMicroservices.Infrastructure.Models;
using ECoursesMicroservices.Main.BusinessLogic.DTOs.Tags;
using MediatR;

namespace ECoursesMicroservices.Main.BusinessLogic.Features.Tags.Queries;
public class GetTagsPagedQuery : IRequest<PagedResult<TagDto>>, IPagedRequest
{
    public string? Name { get; set; }
    public bool IncludeChild { get; set; }
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
