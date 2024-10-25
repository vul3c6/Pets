using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Dtos;
using Pets.Models;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DietRecoedController : ControllerBase
    {
        private readonly ILogger<DietRecoedController> _logger;
        private readonly IDietRecoeds _DietRecoeds;

        public DietRecoedController(ILogger<DietRecoedController> logger, IDietRecoeds DietRecoed)
        {
            _logger = logger;
            _DietRecoeds = DietRecoed;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDietRecoeds()
        {
            try
            {
                var DietRecoeds = await _DietRecoeds.GetAllDietRecoeds();
                return Ok(new
                {
                    Success = true,
                    Message = "All LostPets Returned.",
                    DietRecoeds
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDietRecoedsById(Guid id)
        {
            try
            {
                var DietRecoed = await _DietRecoeds.GetDietRecordsById(id);
                return Ok(new { Success = true, Message = "DietRecoeds Returned.", DietRecoed });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateDietRecoeds(DietRecoedsForCreactionDto DietRecoed)
        {
            try
            {
                var newDietRecoed = await _DietRecoeds.CreateDietRecords(DietRecoed);
                return Ok(new { Success = true, Message = "DietRecoeds Created.", newDietRecoed });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateDietRecoeds(Guid id, DietRecoedsForUpdateDto DietRecoed)
        {
            try
            {
                await _DietRecoeds.UpdateDietRecords(id, DietRecoed);
                return Ok(new { Success = true, Message = "DietRecoeds Updated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDietRecoeds(Guid id)
        {
            try
            {
                await _DietRecoeds.DeleteDietRecords(id);
                return Ok(new { Success = true, Message = "DietRecoeds Deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //
        [HttpGet]
        [Route("myPet/{pid}")]
        public async Task<IActionResult> GetDietRecordsByPid(Guid pid)
        {
            try
            {
                var dietRecords = await _DietRecoeds.GetDietRecordsByPid(pid);
                return Ok(new
                {
                    Success = true,
                    Message = "DietRecords Returned.",
                    DietRecords = dietRecords
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
