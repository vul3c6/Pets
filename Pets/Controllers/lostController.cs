using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Models;

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
    }
}
