namespace ECoursesMicroservices.Infrastructure.Interfaces;
public interface IPagedRequest
{
    public int PageSize { get; set; }
    public int PageNumber { get; set; }
}
