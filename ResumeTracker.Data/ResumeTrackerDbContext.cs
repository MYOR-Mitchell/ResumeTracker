using Microsoft.EntityFrameworkCore;
using ResumeTracker.Core.Models;

namespace ResumeTracker.Data
{
    public class ResumeTrackerDbContext : DbContext
    {
        public ResumeTrackerDbContext(DbContextOptions<ResumeTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<TrackedApplication> TrackedApplications { get; set; }
    }
}
