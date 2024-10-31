using Microsoft.AspNetCore.Mvc;
using Pets.Dtos;
using Pets.Interfaces;
using Pets.Models;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActivitiesController : ControllerBase
    {
        private readonly ILogger<ActivitiesController> _logger;
        private readonly IActivities _activities;

        public ActivitiesController(ILogger<ActivitiesController> logger, IActivities activities)
        {
            _logger = logger;
            _activities = activities;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllActivities()
        {
            try
            {
                var Activities = await _activities.GetAllActivities();
                return Ok(new
                {
                    Success = true,
                    Message = "All Activities Returned.",
                    Activities
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetActivitiesById(Guid id)
        {
            try
            {
                var activities = await _activities.GetActivitiesById(id);
                return Ok(new { Success = true, Message = "Activities Returned.", activities });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateActivities(ActivitiesForCreactionDto activities)
        {
            try
            {
                var newActivities = await _activities.CreateActivities(activities);
                return Ok(new { Success = true, Message = "Activities Created.", newActivities });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateActivities(Guid id, ActivitiesForUpdateDto activities)
        {
            try
            {
                await _activities.UpdateActivities(id, activities);
                return Ok(new { Success = true, Message = "Activities Updated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteActivities(Guid id)
        {
            try
            {
                await _activities.DeleteActivities(id);
                return Ok(new { Success = true, Message = "Activities Deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("myPet/{pid}")]
        public async Task<IActionResult> GetActivtiesByPid(Guid pid)
        {
            try
            {
                var Activties = await _activities.GetActivitiesByPid(pid);
                return Ok(new
                {
                    Success = true,
                    Message = "Activties Returned.",
                    activities = Activties
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
