using Pets.Models;
using Pets.Dtos;

namespace Pets.Interfaces
{
    public interface Ilost
    {
        // 走失寵物資料的介面
        public Task<IEnumerable<lost>> GetAllLostPets();
        public Task<lost> GetLostById(Guid id); 
        public Task<lostForCreationDto> CreateLost(lostForCreationDto lost);
        public Task UpdateLost(Guid id, lostForUpdateDto lost);
        public Task DeleteLost(Guid id);
    }
}
