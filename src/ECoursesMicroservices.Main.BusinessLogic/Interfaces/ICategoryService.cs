namespace ECoursesMicroservices.Main.BusinessLogic.Interfaces;
public interface ICategoryService
{
    Task<bool> IsCategoryExists(Guid categoryId, CancellationToken token);
    Task<bool> IsCategoryExists(string categoryName, CancellationToken token);
}
