using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Dtos;
using Pets.Models;


namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class myPetController : ControllerBase
    {
        private readonly ILogger<myPetController> _logger;
        private readonly ImyPet _myPet;
        public myPetController(ILogger<myPetController> logger, ImyPet myPet)
        {
            _logger = logger;
            _myPet = myPet;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllMyPets()
        {
            try
            {
                var myPets = await _myPet.GetAllMyPets();
                return Ok(new
                {
                    Success = true,
                    Message = "All myPets Returned.",
                    myPets
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpGet]
        //[Route("{id}")]
        //public async Task<IActionResult> GetMyPetById(Guid id)
        //{
        //    try
        //    {
        //        var myPet = await _myPet.GetMyPetById(id);
        //        return Ok(new
        //        {
        //            Success = true,
        //            Message = "myPet Returned.",
        //            myPet
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}

        [HttpPost]
        public async Task<IActionResult> CreateMyPet(myPetForCreationDto myPet)
        {
            try
            {
                var newMyPet = await _myPet.CreateMyPet(myPet);
                return Ok(new
                {
                    Success = true,
                    Message = "myPet Created.",
                    newMyPet
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateMyPet(Guid id, myPetForUpdateDto myPet)
        {
            try
            {
                await _myPet.UpdateMyPet(id, myPet);
                return Ok(new
                {
                    Success = true,
                    Message = "myPet Updated."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteMyPet(Guid id)
        {
            try
            {
                await _myPet.DeleteMyPet(id);
                return Ok(new
                {
                    Success = true,
                    Message = "myPet Deleted."
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}