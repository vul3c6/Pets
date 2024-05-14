using Pets.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Pets.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Cross1Controller : ControllerBase
    {
        // 記錄和追蹤應用程式的運行時行為及各種訊息，如警告、錯誤等
        private readonly ILogger<Cross1Controller> _logger;
        // 宣告此控制器所要依賴的介面（Interface），而不是其實作
        private readonly ICross1 _cross;
        public Cross1Controller(ILogger<Cross1Controller> logger, ICross1 cross)
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
    }
}
