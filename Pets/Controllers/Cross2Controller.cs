using Microsoft.AspNetCore.Mvc;
using Pets.Interfaces;
using Pets.Repositories;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cross2Controller : ControllerBase
    {
        // 記錄和追蹤應用程式的運行時行為及各種訊息，如警告、錯誤等
        private readonly ILogger<Cross2Controller> _logger;
        // 宣告此控制器所要依賴的介面（Interface），而不是其實作
        private readonly ICross2 _cross;
        public Cross2Controller(ILogger<Cross2Controller> logger, ICross2 cross)
        {
            // 注入Logger 服務
            _logger = logger;
            // 注入Cross 服務
            _cross = cross;
        }
        [HttpGet("PetDetailsForVaccine/{id}")]
        public async Task<IActionResult> GetPetDetailsByVaccineId(Guid id)
        {
            try
            {
                // 取得指定id 的會員資料
                var calendarDetails = await _cross.GetPetDetailsByVaccineId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定id 會員的所有行事曆詳細資料成功",
                    Data = calendarDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("VaccineDetailsForPet/{id}")]
        public async Task<IActionResult> GetVaccinesDetailsByPetId(Guid id)
        {
            try
            {
                // 取得指定id 的行事曆資料
                var memberDetails = await _cross.GetVaccinesDetailsByPetId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定id 行事曆的所有會員詳細資料成功",
                    Data = memberDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
