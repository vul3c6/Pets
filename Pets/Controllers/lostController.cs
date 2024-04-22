using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Models;
using Pets.Dtos;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class lostController : ControllerBase
    {
        private readonly ILogger<lostController> _logger; 
        private readonly Ilost _lost;
            
        public lostController(ILogger<lostController> logger, Ilost lost) 
        { 
            _logger = logger;
            _lost = lost; 
        }

        [HttpGet] 
        public async Task<IActionResult> GetAllLostPets() 
        { 
            try
            { 
                var losts = await _lost.GetAllLostPets(); 
                return Ok(new 
                { 
                    Success = true, 
                    Message = "All LostPets Returned.",
                    losts
                }); 
            } 
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message); 
            } 
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLostById(Guid id)
        {
            try
            {
                var lost = await _lost.GetLostById(id);
                return Ok(new { Success = true, Message = "Lost Returned.", lost });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateLost(lostForCreationDto lost)
        {
            try
            {
                var newLost = await _lost.CreateLost(lost);
                return Ok(new { Success = true, Message = "Lost Created.", newLost });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateLost(Guid id, lostForUpdateDto lost)
        {
            try
            {
                await _lost.UpdateLost(id, lost);
                return Ok(new { Success = true, Message = "Lost Updated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLost(Guid id)
        {
            try
            {
                await _lost.DeleteLost(id);
                return Ok(new { Success = true, Message = "Lost Deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
