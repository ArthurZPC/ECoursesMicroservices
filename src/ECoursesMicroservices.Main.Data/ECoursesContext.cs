using ECoursesMicroservices.Main.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECoursesMicroservices.Main.Data;
public class ECoursesContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Tag> Tags => Set<Tag>();

    public ECoursesContext(DbContextOptions<ECoursesContext> options) : base(options) { }

}
