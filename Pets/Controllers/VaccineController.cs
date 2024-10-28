using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Models;
using Pets.Dtos;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly ILogger<VaccineController> _logger;
        private readonly IVaccine _vaccine;

        public VaccineController(ILogger<VaccineController> logger, IVaccine vaccine)
        {
            _logger = logger;
            _vaccine = vaccine;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVaccinePets()
        {
            try
            {
                var vaccine = await _vaccine.GetAllVaccinePets();
                return Ok(new
                {
                    Success = true,
                    Message = "All VaccinePets Returned.",
                    vaccine
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetVaccineById(Guid id)
        {
            try
            {
                var vaccine = await _vaccine.GetVaccineById(id);
                return Ok(new { Success = true, Message = "Vaccine Returned.", vaccine });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateVaccine(VaccineForCreationDto vaccine)
        {
            try
            {
                var newVaccine = await _vaccine.CreateVaccine(vaccine);
                return Ok(new { Success = true, Message = "Vaccine Created.", newVaccine });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateVaccine(Guid id, VaccineForUpdateDto vaccine)
        {
            try
            {
                await _vaccine.UpdateVaccine(id, vaccine);
                return Ok(new { Success = true, Message = "Vaccine Updated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteVaccine(Guid id)
        {
            try
            {
                await _vaccine.DeleteVaccine(id);
                return Ok(new { Success = true, Message = "Vaccine Deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        [Route("myPet/{pid}")]
        public async Task<IActionResult> GetVaccinesByPid(string pid)
        {
            try
            {
                var vaccines = await _vaccine.GetVaccinesByPid(pid);
                return Ok(new
                {
                    Success = true,
                    Message = "Vaccines Returned.",
                    Vaccines = vaccines
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
