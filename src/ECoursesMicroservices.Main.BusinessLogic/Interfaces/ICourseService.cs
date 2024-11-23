namespace ECoursesMicroservices.Main.BusinessLogic.Interfaces;
public interface ICourseService
{
    Task<bool> IsCourseExists(Guid courseId, CancellationToken token);
}
