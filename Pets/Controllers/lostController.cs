using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Dtos;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LostController : ControllerBase
    {
        private readonly ILogger<LostController> _logger; 
        private readonly ILost _lost;
            
        public LostController(ILogger<LostController> logger, ILost lost) 
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
        public async Task<IActionResult> CreateLost(LostForCreationDto lost)
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
        public async Task<IActionResult> UpdateLost(Guid id, LostForUpdateDto lost)
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
        [HttpGet]
        [Route("member/{Maccount}")]
        public async Task<IActionResult> GetLostsByMaccount(string Maccount)
        {
            try
            {
                var losts = await _lost.GetLostsByMaccount(Maccount);
                return Ok(new { Success = true, Message = "Losts Returned.", losts });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
