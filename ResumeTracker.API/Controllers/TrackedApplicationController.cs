using Microsoft.AspNetCore.Mvc;
using ResumeTracker.Core.Interfaces;
using ResumeTracker.Core.Models;

namespace ResumeTracker.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TrackedApplicationsController : ControllerBase
    {
        private readonly ITrackedApplicationRepository _repo;

        public TrackedApplicationsController(ITrackedApplicationRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _repo.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _repo.GetByIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TrackedApplication app)
        {
            await _repo.AddAsync(app);
            return CreatedAtAction(nameof(GetById), new { id = app.Id }, app);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, TrackedApplication app)
        {
            if(id != app.Id)
                return BadRequest();
            await _repo.UpdateAsync(app);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchByCompanyName([FromQuery] string name)
        {
            var apps = await _repo.GetAllAsync();
            var results = apps
                .Where(a => a.CompanyName.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(results);
        }
    }
}
