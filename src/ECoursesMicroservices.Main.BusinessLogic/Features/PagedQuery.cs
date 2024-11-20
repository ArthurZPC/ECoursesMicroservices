using ECoursesMicroservices.Infrastructure.Interfaces;

namespace ECoursesMicroservices.Main.BusinessLogic.Features;
public class PagedQuery : IPagedRequest
{
    public int PageSize { get; set; } = 10;
    public int PageNumber { get; set; } = 1;
}
