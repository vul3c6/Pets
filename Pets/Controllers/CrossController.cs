using Pets.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrossController : ControllerBase
    {
        // 記錄和追蹤應用程式的運行時行為及各種訊息，如警告、錯誤等
        private readonly ILogger<CrossController> _logger;
        // 宣告此控制器所要依賴的介面（Interface），而不是其實作
        private readonly ICross _cross;
        public CrossController(ILogger<CrossController> logger, ICross cross)
        {
            // 注入Logger 服務
            _logger = logger;
            // 注入Cross 服務
            _cross = cross;
        }
        [HttpGet("PetsForMember/{id}")]
        public async Task<IActionResult> GetPetDetailsByMemberId(Guid id)
        {
            try
            {
                // 取得指定id 的會員資料
                var PetDetails = await _cross.GetPetDetailsByMemberId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定id 會員的所有寵物詳細資料成功",
                    Data = PetDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("VaccinesForPet/{id}")]
        public async Task<IActionResult> GetVaccinesDetailsByPetId(Guid id)
        {
            try
            {
                // 取得指定id 的會員資料
                var VaccineDetails = await _cross.GetVaccinesDetailsByPetId(id);
                return Ok(new
                {
                    Success = true,
                    Message = "取得指定寵物的疫苗詳細資料成功",
                    Data = VaccineDetails
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
