using ECoursesMicroservices.Infrastructure.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ECoursesMicroservices.Main.BusinessLogic.Features;
public class PagedQuery : IPagedRequest
{
    [Required]
    public int PageSize { get; set; } = 10;

    [Required]
    public int PageNumber { get; set; } = 1;
}
