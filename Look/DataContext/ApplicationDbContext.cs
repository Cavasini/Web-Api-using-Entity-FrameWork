using Look.Model;
using Microsoft.EntityFrameworkCore;

namespace Look.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<TimeTracker> TimeTrackers { get; set; }
    }
}
