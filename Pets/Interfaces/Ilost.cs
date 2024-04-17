using Pets.Models;

namespace Pets.Interfaces
{
    public interface Ilost
    {
        // 查詢所有走失寵物資料的介面
        public Task<IEnumerable<lost>> GetAllLostPets();
    }
}
