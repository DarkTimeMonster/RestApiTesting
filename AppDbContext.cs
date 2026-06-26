using Microsoft.EntityFrameworkCore;

namespace Skilltest
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<SkillTask> Tasks { get; set; }
    }
}
