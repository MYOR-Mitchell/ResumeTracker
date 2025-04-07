using ResumeTracker.Core.Models;

namespace ResumeTracker.Core.Interfaces
{
    public interface ITrackedApplicationRepository
    {
        Task<IEnumerable<TrackedApplication>> GetAllAsync();
        Task<TrackedApplication?> GetByIdAsync(int id);
        Task AddAsync(TrackedApplication application);
        Task UpdateAsync(TrackedApplication application);
        Task DeleteAsync(int id);
    }
}
