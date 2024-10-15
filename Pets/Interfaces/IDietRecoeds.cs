using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface IDietRecoeds
    {
        // 查詢所有DietRecoeds資料的介面
        public Task<IEnumerable<DietRecords>> GetAllDietRecoeds();
        // 查詢單一DietRecords資料（依指定id）
        public Task<DietRecords> GetDietRecordsById(Guid id);
        // 新增DietRecords資料
        public Task<DietRecoedsForCreactionDto> CreateDietRecords(DietRecoedsForCreactionDto DietRecord);
        // 更新DietRecords資料（依指定id）
        public Task UpdateDietRecords(Guid id, DietRecoedsForUpdateDto DietRecord);
        // 刪除DietRecords資料（依指定id）
        public Task DeleteDietRecords(Guid id);
    }
}
