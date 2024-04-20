using Pets.Models;
using Pets.Dtos;
namespace Pets.Interfaces
{
    public interface Ilost
    {
        // 查詢所有走失寵物資料的介面
        public Task<IEnumerable<lost>> GetAllLostPets();
        public Task<lostForCreationDto> CreateLost(lostForCreationDto lost);
        public Task UpdateLost(Guid id, lostForUpdateDto lost);
        public Task DeleteLost(Guid id);
    }
}
