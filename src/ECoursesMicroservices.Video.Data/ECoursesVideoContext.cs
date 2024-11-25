using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Video.Data;
public class ECoursesVideoContext : DbContext
{
    public DbSet<Entities.Video> Videos => Set<Entities.Video>();

    public ECoursesVideoContext(DbContextOptions<ECoursesVideoContext> options) : base(options) { }
}
