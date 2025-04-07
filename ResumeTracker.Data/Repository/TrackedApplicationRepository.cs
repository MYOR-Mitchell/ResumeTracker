using Microsoft.EntityFrameworkCore;
using ResumeTracker.Core.Interfaces;
using ResumeTracker.Core.Models;


namespace ResumeTracker.Data.Repository
{
    public class TrackedApplicationRepository : ITrackedApplicationRepository
    {
        private readonly ResumeTrackerDbContext _context;

        public TrackedApplicationRepository(ResumeTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TrackedApplication>> GetAllAsync() =>
            await _context.TrackedApplications.ToListAsync();

        public async Task<TrackedApplication?> GetByIdAsync(int id) =>
            await _context.TrackedApplications.FindAsync(id);

        public async Task AddAsync(TrackedApplication application)
        {
            _context.TrackedApplications.Add(application);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TrackedApplication application)
        {
            _context.TrackedApplications.Update(application);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.TrackedApplications.FindAsync(id);
            if(entity != null)
            {
                _context.TrackedApplications.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
