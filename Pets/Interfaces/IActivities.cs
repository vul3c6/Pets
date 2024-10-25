using Pets.Dtos;
using Pets.Models;

namespace Pets.Interfaces
{
    public interface IActivities
    {
        // 查詢所有Activities資料的介面
        public Task<IEnumerable<Activities>> GetAllActivities();
        // 查詢單一Activities資料（依指定id）
        public Task<Activities> GetActivitiesById(Guid id);
        // 新增Activities資料
        public Task<ActivitiesForCreactionDto> CreateActivities(ActivitiesForCreactionDto activities);
        // 更新Activities 資料（依指定id）
        public Task UpdateActivities(Guid id, ActivitiesForUpdateDto activities);
        // 刪除Activities 資料（依指定id）
        public Task DeleteActivities(Guid id);
        //
        public Task<IEnumerable<Activities>> GetActivitiesByPid(Guid pid);
    }
}
