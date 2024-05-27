using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Models;
using Pets.Dtos;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiveController : ControllerBase
    {
        private readonly ILogger<ReceiveController> _logger;
        private readonly IReceive _receive;

        public ReceiveController(ILogger<ReceiveController> logger, IReceive receive)
        {
            _logger = logger;
            _receive = receive;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReceivePets()
        {
            try
            {
                var receive = await _receive.GetAllReceivePets();
                return Ok(new
                {
                    Success = true,
                    Message = "All ReceivePets Returned.",
                    receive
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        //[HttpGet("{id}")]
        //public async Task<IActionResult> GetReceiveById(Guid id)
        //{
        //    try
        //    {
        //        var receive = await _receive.GetReceiveById(id);
        //        return Ok(new { Success = true, Message = "Receive Returned.", receive });
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        //}
        [HttpPost]
        public async Task<IActionResult> CreateReceive(ReceiveForCreationDto receive)
        {
            try
            {
                var newReceive = await _receive.CreateReceive(receive);
                return Ok(new { Success = true, Message = "Receive Created.", newReceive });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateReceive(Guid id, ReceiveForUpdateDto receive)
        {
            try
            {
                await _receive.UpdateReceive(id, receive);
                return Ok(new { Success = true, Message = "Receive Updated." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteReceive(Guid id)
        {
            try
            {
                await _receive.DeleteReceive(id);
                return Ok(new { Success = true, Message = "Receive Deleted." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
